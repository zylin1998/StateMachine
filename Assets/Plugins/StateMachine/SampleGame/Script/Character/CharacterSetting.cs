using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    [Serializable]
    public class CharacterSetting
    {
        [Header("移動速度"), SerializeField, Range(  1f, 15f)]
        private float _MoveSpeed;
        [Header("轉向速度"), SerializeField, Range(0.1f,  1f)]
        private float _TurnSpeed;
        [Header("攻擊冷卻"), SerializeField, Range(0.1f,  1f)]
        private float _CoolDown;
        [Header("攻擊速度"), SerializeField, Range(  1f, 15f)]
        private float _AttackSpeed;
        [Header("攻擊傷害"), SerializeField, Min(1f)]
        private float _Damage;
        [Header("角色生命"), SerializeField, Min(1f)]
        private float _Health;
        [Header("受傷冷卻"), SerializeField, Range(0.1f, 1f)]
        private float _HurtPause;
        [Header("身體顏色"), SerializeField]
        private Character.BodyColor _BodyColor;

        public float MoveSpeed   => _MoveSpeed;
        public float TurnSpeed   => _TurnSpeed;
        public float CoolDown    => _CoolDown;
        public float AttackSpeed => _AttackSpeed;
        public float Damage      => _Damage;
        public float Health      => _Health;
        public float HurtPause   => _HurtPause;
        public Character.BodyColor BodyColor => _BodyColor;
    }
}
