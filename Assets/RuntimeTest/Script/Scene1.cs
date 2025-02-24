using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace StateMachineX.RuntimeTest
{
    public class Scene1 : MonoBehaviour
    {
        [SerializeField]
        private Button _Button;

        public IStateMachine Machine { get; private set; }

        private void Awake()
        {
            var state = StateMachine.FunctionalState()
                .EnterWhen(() => gameObject.activeSelf)
                .DoOnEnter(() => Debug.Log("State1 Entered"))
                .DoTick(() => Debug.Log("State1 Ticked"));

            Machine = StateMachine.SingleEntrance()
                .WithStates(state);

            Machine.Update().AddTo(this);

            _Button.onClick.AddListener(() => SceneManager.LoadScene(1));
        }
    }
}
