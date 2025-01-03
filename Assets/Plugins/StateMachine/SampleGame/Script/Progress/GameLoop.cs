using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.SampleGame
{
    public class GameLoop : MonoBehaviour
    {
        [Header("資料庫")]
        [SerializeField]
        private DataBase        _DataBase;
        [SerializeField]
        private PropertyManager _PropertyManager;
        [Header("UI物件")]
        [SerializeField]
        private GameLoopUI _UI;
        [Header("環境物件")]
        [SerializeField]
        private Transform _Enviroment;
        [Header("攻擊物件生成"), SerializeField]
        private Attacking _Attacking;
        [Header("遊戲設定")]
        [SerializeField]
        private GameSetting _Setting;
        
        private float _MinBoarderY = -6.5f, _MaxBoarderY = 6.5f;
        private float _MinBoarderX =  -11f, _MaxBoarderX =  11f;

        private float _Ready;
        private float _Spawn;

        private Action _OnGameOver = () => {};

        public event Action OnGameOver 
        {
            add    => _OnGameOver += value;

            remove => _OnGameOver -= value;
        }

        public Player Player { get; private set; }

        public Queue<Enemy>   EnemyPool { get; } = new();
        public HashSet<Enemy> OnScene   { get; private set; } = new();

        public bool GameOver { get; set; }

        public int  Score    { get; private set; }
        public int  Capacity 
        {
            get 
            {
                var capacity = _Setting.Enemies + Score / _Setting.GrownRate;

                return capacity <= _Setting.MaxEnemies ? capacity : _Setting.MaxEnemies;
            }
        }

        public float SpawnTime 
        {
            get 
            {
                var spawn = _Setting.SpawnTime * (1 - 0.05f * Score / _Setting.GrownRate);

                return spawn >= 0.5f ? spawn : 0.5f;
            }
        }

        public IStateMachine Machine { get; private set; }

        private IDisposable _Register;

        private void Awake()
        {
            //Physics2D.IgnoreLayerCollision(6, 7);
            Physics2D.IgnoreLayerCollision(7, 8);

            _Setting = _DataBase.GameSetting;

            Player = Instantiate(_DataBase.Player, _Enviroment);

            _Attacking.Set(_DataBase.Attack);
            _Attacking.Binder += TakeDamage;

            OnGameOver += _Attacking.RecycleAll;

            var init = StateMachine.FunctionalState()
                .DoOnEnter(Initialize)
                .WithId(1);

            var ready = StateMachine.FunctionalState()
                .ExitWhen(IsReady)
                .DoOnEnter(ReloadTimer)
                .DoOnExit(CloseTimer)
                .DoFixedTick(UpdateTimer)
                .WithId(2);

            var loop = StateMachine.FunctionalState()
                .ExitWhen(() => GameOver)
                .DoOnEnter(EnterLoop)
                .DoFixedTick(SpawnEnemy)
                .WithId(3);

            var endLoop = StateMachine.FunctionalState()
                .DoOnEnter(Disable)
                .WithId(4);

            Machine = StateMachine.SingleEntrance()
                .WithStates(init, ready, loop, endLoop)
                .Sequence()
                .OrderBy(1, 2, 3, 4);
        }

        public void Enable()
        {
            _Register = Machine.FixedUpdate();
        }

        public void Disable()
        {
            _Register.Dispose();

            Player.Disable();

            foreach (var enemy in OnScene)
            {
                enemy.Disable();
            }

            _OnGameOver.Invoke();
        }

        private bool IsReady() => _Ready <= -1;

        private void Initialize()
        {
            GameOver = false;

            RecycleAll();

            _PropertyManager.Initialize();

            var setting  = _DataBase.PlayerSetting;
            var property = _PropertyManager.GetPlayer();

            property.Health = setting.Health;

            Player.Initialize();

            Player.Character.Set(setting);
            Player.Character.Set(property);
            Player.Character.Set(_Attacking);

            Score = 0;

            _UI.SetScore(Score);
            _UI.SetLife(property.Health);
        }

        private void ReloadTimer() 
        {
            _Ready = 3f;

            _UI.SetTimer(_Ready);
        }

        private void UpdateTimer() 
        {
            _Ready -= Time.fixedDeltaTime;

            _UI.SetTimer(_Ready);
        }

        private void CloseTimer()
        {
            _UI.CloseTimer();
        }

        private void EnterLoop() 
        {
            Player.Enable();

            CreateEnemies(Capacity);
        }

        private void SpawnEnemy() 
        {
            OnScene = CheckAlive().ToHashSet();
            
            if (_Spawn <= 0f && Capacity > OnScene.Count) 
            {
                var enemy = CreateEnemy();

                enemy.Enable();

                OnScene.Add(enemy);

                _Spawn = SpawnTime;
            }

            _Spawn -= Time.fixedDeltaTime;
        }

        private void CreateEnemies(int count) 
        {
            for(var i = 0; i < count; i++) 
            {
                var enemy = CreateEnemy();

                enemy.Enable();

                OnScene.Add(enemy);
            }
        }

        private Enemy CreateEnemy()
        {
            var enemy = default(Enemy);

            if (EnemyPool.Any()) 
            {
                enemy = EnemyPool.Dequeue(); 
            }

            else 
            { 
                enemy = Instantiate(_DataBase.Enemy, _Enviroment);

                enemy.Character.Set(_Attacking);
                
                enemy.Set(Player);
            }

            var setting  = _DataBase.EnemySetting;
            var property = _PropertyManager.GetEnemy();

            property.Health = setting.Health;

            enemy.Character.Set(setting);
            enemy.Character.Set(property);

            enemy.transform.SetPositionAndRotation(GetPosition(), Quaternion.identity);

            return enemy;
        }

        private IEnumerable<Enemy> CheckAlive() 
        {
            var hasDead = false;

            foreach (var enemy in OnScene) 
            {
                if (enemy.Character.IsDead) 
                {
                    hasDead = true;

                    Score += 1;

                    _UI.SetScore(Score);

                    Recycle(enemy);

                    continue;
                }

                yield return enemy;
            }

            if (hasDead) { _PropertyManager.RemoveDeadEnemy(); }
        }

        private void Recycle(Enemy enemy) 
        {
            enemy.Disable();

            EnemyPool.Enqueue(enemy);
        }

        private void RecycleAll()
        {
            foreach (var enemy in OnScene)
            {
                EnemyPool.Enqueue(enemy);
            }

            OnScene.Clear();
        }

        private Vector3 GetPosition() 
        {
            var positions = new[]
            {
                new Vector2(_MinBoarderX, UnityEngine.Random.Range(_MinBoarderY, _MaxBoarderY)),
                new Vector2(_MaxBoarderX, UnityEngine.Random.Range(_MinBoarderY, _MaxBoarderY)),
                new Vector2(UnityEngine.Random.Range(_MinBoarderX, _MaxBoarderX), _MinBoarderY),
                new Vector2(UnityEngine.Random.Range(_MinBoarderX, _MaxBoarderX), _MaxBoarderY),
            };

            var index = UnityEngine.Random.Range(0, 3);

            return positions[index];
        }

        private void TakeDamage(AttackInfo attack) 
        {
            var tag = attack.Tag;
            
            if (tag == Group.Player) 
            {
                _PropertyManager.SetPlayer(attack.Damage);

                var health = _PropertyManager.GetPlayer().Health; 

                _UI.SetLife(health);

                if (health <= 0) { GameOver = true; }
            }

            if (tag == Group.Enemy)
            {
                _PropertyManager.SetEnemy(attack.Id, attack.Damage);
            }
        }
    }
}
