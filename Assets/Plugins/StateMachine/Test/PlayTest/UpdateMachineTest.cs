using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StateMachineX.PlayTest
{
    public class UpdateMachineTest
    {
        [UnityTest]
        public IEnumerator UpdateStateMachineTest()
        {
            var count = 0;

            var state1 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 0)
                .ExitWhen (() => count == 10)
                .DoTick(() => count++)
                .WithId("State1");

            var state2 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 10)
                .ExitWhen (() => count == 30)
                .DoOnEnter(() => count = 20)
                .DoTick(() => count++)
                .WithId("State2");

            var machine = StateMachine.SingleEntrance()
                .WithStates(state1, state2);

            var register = machine.Update();

            for (var index = 0; index <= 30; index++)
            {
                yield return null;

                if (index.IsClamp( 0,  9)) { Assert.AreEqual(index +  1, count); }
                if (index.IsClamp(10, 19)) { Assert.AreEqual(index + 11, count); }
                if (index.IsClamp(20, 30)) { Assert.AreEqual(        30, count); }

                //DebugDisplay(index, machine.Current.Identity, count);
            }
        }

        [UnityTest]
        public IEnumerator FixedUpdateStateMachineTest()
        {
            var count = 0;

            var state1 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 0)
                .ExitWhen(() => count == 10)
                .DoFixedTick(() => { /*Debug.Log("FixedTick");*/ count++; })
                .WithId("Sttate1");

            var state2 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 10)
                .ExitWhen(() => count == 30)
                .DoOnEnter(() => count = 20)
                .DoFixedTick(() => count++)
                .WithId("Sttate2");

            var machine = StateMachine.SingleEntrance()
                .WithStates(state1, state2);

            var register = machine.FixedUpdate();

            yield return null;

            for (var index = 0; index <= 30; index++)
            {
                yield return new WaitForFixedUpdate();

                if (index.IsClamp(0,   9)) { Assert.AreEqual(index + 1, count); }
                if (index.IsClamp(10, 19)) { Assert.AreEqual(index + 11, count); }
                if (index.IsClamp(20, 30)) { Assert.AreEqual(        30, count); }

                //DebugDisplay(index, machine.Current.Identity, count);
            }
        }

        [UnityTest]
        public IEnumerator LateUpdateStateMachineTest()
        {
            var count = 0;

            var state1 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 0)
                .ExitWhen(() => count == 10)
                .DoLateTick(() => count++)
                .WithId("Sttate1");

            var state2 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 10)
                .ExitWhen(() => count == 30)
                .DoOnEnter(() => count = 20)
                .DoLateTick(() => count++)
                .WithId("Sttate2");

            var machine = StateMachine.SingleEntrance()
                .WithStates(state1, state2);

            var register = machine.LateUpdate();

            yield return new WaitForEndOfFrame();

            for (var index = 0; index <= 30; index++)
            {
                yield return new WaitForEndOfFrame();

                if (index.IsClamp(0,   9)) { Assert.AreEqual(index + 1, count); }
                if (index.IsClamp(10, 19)) { Assert.AreEqual(index + 11, count); }
                if (index.IsClamp(20, 30)) { Assert.AreEqual(        30, count); }

                //DebugDisplay(index, machine.Current.Identity, count);
            }
        }

        private void DebugDisplay(int index, object id, int count) 
        {
            var format = "Index: {0}, State: {1}, Count: {2}";
            var args = new[] { index, id, count };

            Debug.Log(string.Format(format, args));
        }
    }

    internal static class MathExtension 
    {
        public static bool IsClamp(this int value, int min, int max) 
        {
            return value >= min && value <= max;
        }
    }
}
