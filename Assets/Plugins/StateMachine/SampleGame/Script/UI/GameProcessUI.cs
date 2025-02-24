using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace StateMachineX.SampleGame
{
    public class GameProcessUI : MonoBehaviour
    {
        [SerializeField]
        private Button _Start;
        [SerializeField]
        private Score  _Highest;
        [SerializeField]
        private Score  _Current;

        public int Highest { get; private set; }

        private void Awake()
        {
            SetHighest(0);
        }

        public void SetHighest(int value) 
        {
            if (Highest > value) { return; }

            _Highest.Set(value);
        }

        public void SetCurrent(int value)
        {
            _Current.Set(value);
        }

        public void AddListener(UnityAction callback) 
        {
            _Start.onClick.AddListener(callback);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close() 
        {
            gameObject.SetActive(false);
        }
    }
}
