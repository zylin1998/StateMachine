using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    [Serializable]
    public class GameSetting
    {
        [Header("場上最大敵人數"), SerializeField]
        private int _MaxEnemies;
        [Header("場上當前敵人數"), SerializeField]
        private int _Enemies;
        [Header("基本生成敵人時間"), SerializeField]
        private float _SpawnTime;
        [Header("難度成長幅度(Score / Rate)"), SerializeField]
        private int _GrownRate;

        public int MaxEnemies => _MaxEnemies;
        public int Enemies => _Enemies;
        public float SpawnTime => _SpawnTime;
        public int GrownRate => _GrownRate;
    }
}
