using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.RuntimeTest
{
    public class UnScaledScene : MonoBehaviour
    {
        private void Start()
        {
            var state1 = StateMachine.FunctionalState()
                .DoOnEnter(() => Debug.Log("State1"))
                .WithId(1);

            var state2 = StateMachine.FunctionalState()
                .DoOnEnter(() => Debug.Log("State2"))
                .WithId(2);

            var state3 = StateMachine.FunctionalState()
                .DoOnEnter(() => Debug.Log("State3"))
                .WithId(3);

            var machine = StateMachine.SingleEntrance()
                .WithStates(state1, state2, state3)
                .Sequence()
                .OrderBy(1, 2, 3);

            machine.Cycle = true;

            machine.FixedUpdate();
        }
    }
}
