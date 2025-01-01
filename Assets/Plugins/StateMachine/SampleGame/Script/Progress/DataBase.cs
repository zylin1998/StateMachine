using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.SampleGame
{
    public class DataBase : MonoBehaviour
    {
        [Header("物件範本")]
        [SerializeField]
        private Player _Player;
        [SerializeField]
        private Enemy  _Enemy;
        [SerializeField]
        private Attack _Attack;
        [Header("角色設定")]
        [SerializeField]
        private CharacterSetting _PlayerSetting;
        [SerializeField]
        private CharacterSetting _EnemySetting;
        [Header("遊戲設定")]
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
