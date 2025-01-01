using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine.SampleGame
{
    [Serializable]
    public class Attacking
    {
        [SerializeField]
        private Transform _DespawnRoot;
        [SerializeField]
        private Attack    _Attack;

        public Queue<Attack> Pool    { get; } = new();

        public List<Attack>  OnScene { get; } = new();

        public Action<AttackInfo> Binder { get; set; } = (info) => { };

        public void Set(Attack attack) 
        {
            _Attack = attack;
        }

        public Attack Spawn(CharacterSetting setting, Vector3 position, Quaternion rotation, Transform parent) 
        {
            var attack = GetOrCreate();
            
            attack.Set(position, rotation);
            attack.Set(this);
            attack.Set(parent);
            attack.Set(setting.AttackSpeed, setting.Damage);

            attack.gameObject.SetActive(true);
            
            OnScene.Add(attack);

            return attack;
        }

        public void Recycle(Attack attack) 
        {
            attack.gameObject.SetActive(false);

            OnScene.Remove(attack);

            Pool.Enqueue(attack);
        } 

        public void RecycleAll() 
        {
            OnScene.ForEach(attack =>
            {
                attack.gameObject.SetActive(false);

                Pool.Enqueue(attack);
            });

            OnScene.Clear();
        }

        private Attack GetOrCreate() 
        {
            if (Pool.Any()) { return Pool.Dequeue(); }

            else 
            {
                var attack = GameObject.Instantiate(_Attack, _DespawnRoot);

                attack.TakeDamage(Binder);

                return attack;
            }
        }
    }
}
