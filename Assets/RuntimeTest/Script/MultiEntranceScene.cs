using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineX.RuntimeTest
{
    public class MultiEntranceScene : MonoBehaviour
    {
        [SerializeField]
        private Text _Text;
        [SerializeField]
        private float _Interval = 1f;
        [SerializeField]
        private int  _Target = 50;
        [SerializeField]
        private int  _Delta = 1;
        
        private int _Count = 0;

        public IStateMachine Machine { get; private set; }

        public int Count 
        {
            get => _Count;

            set
            {
                _Count = value;

                _Text.text = _Count.ToString();
            }
        }

        private void Awake()
        {
            var state1 = StateMachine.FunctionalState()
                .EnterWhen(() => Count <= 0)
                .ExitWhen (() => Count >= 20)
                .DoTick(() => Count += _Delta)
                .WithId(1);

            var state2 = StateMachine.FunctionalState()
                .EnterWhen(() => Count >= 10)
                .ExitWhen (() => Count >= _Target)
                .DoTick(() => Count += _Delta)
                .WithId(2);

            Machine = StateMachine.MultiEntrance()
                .WithStates(state1, state2);

            StartCoroutine(Interval());
        }

        private IEnumerator Interval() 
        {
            while (Count <= _Target) 
            {
                Machine.Transfer();

                Machine.Tick();

                yield return new WaitForSeconds(_Interval);
            }
        }
    }
}
