using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Character _Character;

        public Player Player { get; private set; }

        public Character Character => _Character;

        public IStateMachine Machine { get; private set; }

        private IDisposable _Registration;

        private void Awake()
        {
            var idle = StateMachine.FunctionalState()
                .EnterWhen(IsIdle)
                .ExitWhen(NotIdle)
                .DoOnEnter(() => _Character.Move(Vector2.zero))
                .WithId("Idle");

            var move = StateMachine.FunctionalState()
                .EnterWhen(IsMove)
                .ExitWhen(NotMove)
                .DoFixedTick(Move)
                .WithId("Move");

            var spin = StateMachine.FunctionalState()
                .EnterWhen(IsSpin)
                .ExitWhen(NotSpin)
                .DoFixedTick(Spin)
                .WithId("Spin");

            var attack = StateMachine.FunctionalState()
                .EnterWhen(IsAttack)
                .ExitWhen(NotAttack)
                .DoFixedTick(Attack)
                .WithId("Attack");

            var dead = StateMachine.FunctionalState()
                .EnterWhen(IsDead)
                .ExitWhen(NotDead)
                .DoOnEnter(Dead)
                .WithId("Dead");

            var hurt = StateMachine.FunctionalState()
                .EnterWhen(IsHurt)
                .ExitWhen(NotHurt)
                .DoFixedTick(Hurt)
                .WithId("Hurt");

            Machine = StateMachine.MultiEntrance()
                .WithStates(idle, move, spin, attack, dead, hurt)
                .WithId("StateMachine")
                .WithWatcher();


            if (Machine.Watcher is MonoBehaviour mono)
            {
                mono.transform.SetParent(transform);
            }
        }

        public void Enable()
        {
            _Registration = Machine
                .Update()
                .FixedUpdate()
                .AddTo(gameObject);

            gameObject.SetActive(true);
        }

        public void Disable()
        {
            _Registration.Dispose();

            gameObject.SetActive(false);
        }

        private bool IsIdle()    => Player.Character.IsDead && !_Character.IsDead;
        private bool IsMove()    => !Player.Character.IsDead && !_Character.IsDead;
        private bool IsSpin()    => !Player.Character.IsDead && !_Character.IsDead;
        private bool IsAttack()  => !Player.Character.IsDead && !_Character.IsDead;
        private bool IsDead()    => _Character.IsDead && !_Character.IsHurt;
        private bool IsHurt()    => _Character.IsHurt;
        private bool NotIdle()   => !Player.Character.IsDead || _Character.IsDead;
        private bool NotMove()   => Player.Character.IsDead || _Character.IsDead;
        private bool NotSpin()   => Player.Character.IsDead || _Character.IsDead;
        private bool NotAttack() => Player.Character.IsDead || _Character.IsDead;
        private bool NotDead()   => !_Character.IsDead;
        private bool NotHurt()   => !_Character.IsHurt;

        private void Move()
        {
            var delta = Player.Character.Position - _Character.Position;

            var normalized = delta.normalized;
            
            _Character.Move(normalized);
        }

        private void Spin()
        {
            var direct = Player.Character.Position - _Character.Position;

            _Character.Spin(direct);
        }

        private void Attack()
        {
            _Character.Attack();
        }

        private void Dead()
        {
            _Character.Dead();
        }

        private void Hurt()
        {
            _Character.ChangeColor();
        }

        public void Set(Player player)
        {
            Player = player;
        }
    }
}
