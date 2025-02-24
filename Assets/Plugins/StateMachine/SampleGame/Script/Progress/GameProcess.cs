using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    public class GameProcess : MonoBehaviour
    {
        [SerializeField]
        private GameProcessUI _UI;
        [SerializeField]
        private GameLoop      _Loop;

        private void Awake()
        {
            _UI.AddListener(StartLoop);

            _Loop.OnGameOver += StopLoop;
        }

        private void StartLoop()
        {
            _UI.Close();

            _Loop.Enable();
        }

        private void StopLoop() 
        {
            //_Loop.Disable();

            _UI.SetCurrent(_Loop.Score);
            _UI.SetHighest(_Loop.Score);

            _UI.Open();
        }
    }
}
