using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.SampleGame
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private Text _Text;

        private int _Time;

        public void Set(int time) 
        {
            if (_Time == time) { return; }

            if (!gameObject.activeSelf) { gameObject.SetActive(true); }

            _Time = time;

            _Text.text = _Time > 0 ? _Time.ToString() : "START!";
        }
    }
}
