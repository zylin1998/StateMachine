using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Character    _Character;
        [Header("¿é¤J³]©w"), SerializeField]
        private InputManager _InputManager;
        
        public Character    Character => _Character;

        public InputManager Input     => _InputManager;

        public IStateMachine Machine { get; private set; }

        private IDisposable _Registration;

        private void Awake()
        {
            var idle = StateMachine.FunctionalState()
                .EnterWhen(IsIdle)
                .ExitWhen (NotIdle)
                .DoOnEnter(Move);

            var move = StateMachine.FunctionalState()
                .EnterWhen(IsMove)
                .ExitWhen (NotMove)
                .DoFixedTick(Move);

            var spin = StateMachine.FunctionalState()
                .EnterWhen(IsSpin)
                .ExitWhen(NotSpin)
                .DoOnExit(Spin)
                .DoFixedTick(Spin);

            var attack = StateMachine.FunctionalState()
                .EnterWhen(IsAttack)
                .ExitWhen(NotAttack)
                .DoFixedTick(Attack);

            var dead = StateMachine.FunctionalState()
                .EnterWhen(IsDead)
                .ExitWhen(NotDead)
                .DoOnEnter(Dead);

            var hurt = StateMachine.FunctionalState()
                .EnterWhen(IsHurt)
                .ExitWhen(NotHurt)
                .DoFixedTick(Hurt);

            Machine = StateMachine.MultiEntrance()
                .WithStates(idle, move, spin, attack, dead, hurt);
        }

        public void Enable()
        {
            Machine.Reset();

            _Registration = Machine
                .Update()
                .FixedUpdate();
        }

        public void Disable()
        {
            _Registration.Dispose();

            gameObject.SetActive(false);
        }

        private bool IsIdle()    => Input.Move   == Vector2.zero && !_Character.IsDead;
        private bool IsMove()    => Input.Move   != Vector2.zero && !_Character.IsDead;
        private bool IsSpin()    => Input.Direct != Vector2.zero && !_Character.IsDead;
        private bool IsAttack()  => Input.Attack && !_Character.IsDead;
        private bool IsDead()    => _Character.IsDead && !_Character.IsHurt;
        private bool IsHurt()    => _Character.IsHurt;
        private bool NotIdle()   => Input.Move   != Vector2.zero || _Character.IsDead;
        private bool NotMove()   => Input.Move   == Vector2.zero || _Character.IsDead;
        private bool NotSpin()   => Input.Direct == Vector2.zero || _Character.IsDead;
        private bool NotAttack() => !Input.Attack || _Character.IsDead;
        private bool NotDead()   => !_Character.IsDead;
        private bool NotHurt()   => !_Character.IsHurt;

        public void Initialize() 
        {
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            gameObject.SetActive(true);
        }

        private void Move()
        {
            _Character.Move(Input.Move);
        }

        private void Spin() 
        {
            _Character.Spin(Input.Direct);
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
    }
}
