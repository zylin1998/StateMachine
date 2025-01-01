using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.SampleGame
{
    public class DataBase : MonoBehaviour
    {
        [Header("����d��")]
        [SerializeField]
        private Player _Player;
        [SerializeField]
        private Enemy  _Enemy;
        [SerializeField]
        private Attack _Attack;
        [Header("����]�w")]
        [SerializeField]
        private CharacterSetting _PlayerSetting;
        [SerializeField]
        private CharacterSetting _EnemySetting;
        [Header("�C���]�w")]
        [SerializeField]
        private GameSetting _GameSetting;

        public Attack Attack => _Attack;
        public Player Player => _Player;
        public Enemy  Enemy  => _Enemy;

        public CharacterSetting PlayerSetting => _PlayerSetting;
        public CharacterSetting EnemySetting  => _EnemySetting;
        public GameSetting      GameSetting   => _GameSetting;
    }
}
