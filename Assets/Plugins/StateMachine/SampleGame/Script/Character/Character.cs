using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.SampleGame
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D      _Rigid;
        [SerializeField]
        private SpriteRenderer   _Body;
        [SerializeField]
        private Transform        _AttackPoint;
        [SerializeField]
        private CharacterSetting _Setting;
        [SerializeField]
        private Property         _Property;

        private float _HurtPaused;
        private float _WaitTime  = 0;

        public bool      IsHurt    { get; private set; }
        public Attacking Attacking { get; private set; }

        public int     Id       => _Property.Id;
        public Vector2 Position => transform.position;
        public float   Rotation => _Rigid.rotation;
        public float   Health   => _Property.Health;
        public bool    IsDead   => Health <= 0;

        public void Set(Property property) 
        {
            _Property = property;
        }

        public void Set(CharacterSetting setting) 
        {
            _Setting  = setting;;

            _Body.color = _Setting.BodyColor.Normal;
        }

        public void Set(Attacking attacking) 
        {
            Attacking = attacking;
        }

        public void Move(Vector2 direct)
        {
            var magnitude = direct.magnitude;
            var velocity  = magnitude >= 0.1f ? direct / magnitude * _Setting.MoveSpeed : Vector2.zero;
            
            _Rigid.velocity = velocity;
        }

        public void Spin(Vector2 direct)
        {
            _Rigid.freezeRotation = direct == Vector2.zero;

            var angle  = Vector2.SignedAngle(Vector2.up, direct);
            var target = Quaternion.Euler(0f, 0f, angle);
            var result = Quaternion.Slerp(transform.rotation, target, _Setting.TurnSpeed);

            _Rigid.MoveRotation(result);
        }

        public void RefreshCoolDown() 
        {
            _WaitTime = 0;
        }

        public void Attack() 
        {
            _WaitTime -= Time.fixedDeltaTime;

            if (_WaitTime <= 0)
            {
                Attacking.Spawn(_Setting, _AttackPoint.position, transform.rotation, transform);

                _WaitTime = _Setting.CoolDown;
            }
        }

        public void Hurt() 
        {
            IsHurt = true;

            _HurtPaused = 0f;

            _Body.color = _Setting.BodyColor.Hurt;
        }

        public void Dead() 
        {
            gameObject.SetActive(false);
        }

        public void ChangeColor() 
        {
            _HurtPaused += Time.fixedDeltaTime / _Setting.HurtPause;
            
            IsHurt = _HurtPaused <= 1f;
            
            _Body.color = Color.Lerp(_Setting.BodyColor.Hurt, _Setting.BodyColor.Normal, _HurtPaused);
        }

        [Serializable]
        public struct BodyColor 
        {
            [SerializeField]
            private Color _Normal;
            [SerializeField]
            private Color _Hurt;

            public Color Normal => _Normal;
            public Color Hurt   => _Hurt;
        }
    }
}
