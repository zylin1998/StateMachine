using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace StateMachineX.UnitTest
{
    public class ExpandMachineTest
    {
        [Test]
        public void SequenceStateMachineTest()
        {
            var count = 0;
            var index = 0;

            var machineId = "Machine";
            
            var state1 = StateMachine.FunctionalState()
                .ExitWhen(() => index >= 10)
                .DoTick(() => count = index)
                .WithId(1);

            var state2 = StateMachine.FunctionalState()
                .ExitWhen(() => index >= 20)
                .DoTick(() => count = index * 10)
                .WithId(2);

            var machine = StateMachine.SingleEntrance()
                .WithStates(state1, state2)
                .Sequence()
                .OrderBy(1, 2)
                .WithId(machineId);

            Assert.AreEqual(machineId, machine.Identity);
            Assert.AreEqual(IState.Default, machine.Current);
            Assert.AreEqual(true, machine.HasChild);
            Assert.AreEqual(2, machine.States.Count());
            Assert.IsTrue(machine.States.Contains(state1));
            Assert.IsTrue(machine.States.Contains(state2));
            
            for (; index <= 30; index++) 
            {
                var transfered = machine.Transfer();

                machine.Tick();

                //DebugHelper.Log(string.Format("{0} {1} {2} {3}", machine.Current.Identity, transfered, index, count));

                Assert.AreEqual(index < 20, transfered);

                if      (index <  10) { Assert.AreEqual(index, count);      }
                else if (index <  20) { Assert.AreEqual(index * 10, count); }
                else if (index >= 20) { Assert.AreEqual(190, count);        }
            }

            machine.Dispose();

            Assert.AreNotEqual(machineId, machine.Identity);
            Assert.AreEqual(IState.Default, machine.Current);
            Assert.AreEqual(false, machine.HasChild);
            Assert.AreEqual(0, machine.States.Count());
            Assert.IsFalse(machine.States.Contains(state1));
            Assert.IsFalse(machine.States.Contains(state2));
        }

        [Test]
        public void PhaseStateMachineTest() 
        {
            var count = 0;
            var machineId = "Machine";

            var state1 = StateMachine.FunctionalState()
                .ExitWhen (() => count == 10)
                .DoTick(() => count++)
                .WithId(1);

            var state2 = StateMachine.FunctionalState()
                .ExitWhen (() => count == 20)
                .DoTick(() => count++)
                .WithId(2);

            var state3 = StateMachine.FunctionalState()
                .ExitWhen (() => count == 30)
                .DoTick(() => count++)
                .WithId(3);

            var state4 = StateMachine.FunctionalState()
                .ExitWhen (() => count == 40)
                .DoTick(() => count++)
                .WithId(4);

            var machine1 = StateMachine.SingleEntrance()
                .WithStates(state1, state2)
                .Sequence()
                .OrderBy(1, 2)
                .Phase()
                .EnterWhen(() => count == 0)
                .ExitWhen (() => count == 15)
                .WithId("Phase1");

            var machine2 = StateMachine.SingleEntrance()
                .WithStates(state3, state4)
                .Sequence()
                .OrderBy(3, 4)
                .Phase()
                .EnterWhen(() => count == 15)
                .ExitWhen (() => count == 40)
                .DoOnEnter(() => count = 25)
                .WithId("Phase2");

            var mainMachine = StateMachine.SingleEntrance()
                .WithStates(machine1, machine2)
                .WithId(machineId);

            for (var index = 0; index <= 40; index++) 
            {
                var transfered = mainMachine.Transfer();

                mainMachine.Tick();

                //DebugHelper.Log(string.Format("{0} {1} {2} {3}", mainMachine.Current.Identity, transfered, index, count));

                Assert.AreEqual(index < 30, transfered);

                if (index.IsClamp( 0, 14)) { Assert.AreEqual(index + 1     , count); }
                if (index.IsClamp(15, 29)) { Assert.AreEqual(index + 1 + 10, count); }

                /*var machineId = mainMachine.Current.Identity;
                var stateId   = (mainMachine.Current as IStateMachine)?.Current.Identity;

                string format = "Transfer: {0, 5}, Index: {1, 2}, Machine: {2}, State: {3}, Count: {4, 2}";
                object args   = new[] { transfer, index, machineId, stateId, count };

                DebugHelper.Log(string.Format(format, args));*/
            }
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