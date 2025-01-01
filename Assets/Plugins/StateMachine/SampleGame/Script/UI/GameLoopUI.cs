using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.SampleGame
{
    public class GameLoopUI : MonoBehaviour
    {
        [SerializeField]
        private Timer _Timer;
        [SerializeField]
        private Score _Score;
        [SerializeField]
        private Life  _Life;

        public void SetTimer(float value) 
        {
            _Timer.Set(Mathf.CeilToInt(value));
        }

        public void SetScore(int value) 
        {
            _Score.Set(value);
        }

        public void SetLife(float value) 
        {
            _Life.Set((int)value);
        }

        public void CloseTimer() 
        {
            _Timer.gameObject.SetActive(false);
        }
    }
}
