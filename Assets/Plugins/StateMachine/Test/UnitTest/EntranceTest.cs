using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace StateMachineX.UnitTest
{
    public class BasicMachineTest
    {
        [Test]
        public void SingleEntranceTest()
        {
            var count      = 0;
            var fixedCount = 0;
            var lateCount  = 0;

            var machineId = "Machine";

            var state1 = StateMachine.FunctionalState()
                .EnterWhen(() => count <= 0)
                .ExitWhen (() => count >= 5)
                .DoTick     (() => count += 1)
                .DoFixedTick(() => fixedCount += 1)
                .DoLateTick (() => lateCount += 1)
                .WithId(1);

            var state2 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 5)
                .ExitWhen (() => count >= 10)
                .DoTick(() => count += 1)
                .WithId(2);
            
            var machine = StateMachine.SingleEntrance()
                .WithStates(state1, state2)
                .WithId(machineId);
            
            Assert.AreEqual(machineId, machine.Identity);
            Assert.AreEqual(IState.Default, machine.Current);
            Assert.AreEqual(true, machine.HasChild);
            Assert.AreEqual(2, machine.States.Count());
            Assert.IsTrue(machine.States.Contains(state1));
            Assert.IsTrue(machine.States.Contains(state2));
            
            for (var i = 0; i <= 15; i++) 
            {
                var transfered = machine.Transfer();
                
                machine.Tick();
                machine.FixedTick();
                machine.LateTick();

                //Debug.Log(string.Format("{0} {1} {2} {3}", machine.Current.Identity, transfered, i, count));

                Assert.AreEqual(transfered, i < 10);
                Assert.AreEqual(count     , i < 10 ? i + 1 : 10);
                Assert.AreEqual(fixedCount, i < 5  ? i + 1 : 5 );
                Assert.AreEqual(lateCount , i < 5  ? i + 1 : 5 );
                
                var identity = machine.Current.Identity;

                if (i < 5) { Assert.AreEqual(identity, 1); }
                if (i >= 5 && i < 10) { Assert.AreEqual(identity, 2); }
                if (i >= 10) { Assert.IsFalse(Equals(identity, 1) || Equals(identity, 2)); }
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
        public void MultiEntranceTest() 
        {
            var count      = 0;
            var fixedCount = 0;
            var lateCount  = 0;

            var machineId = "Machine";

            var state1 = StateMachine.FunctionalState()
                .EnterWhen(() => count <= 0)
                .ExitWhen (() => count >= 7)
                .DoTick     (() => count += 1)
                .DoFixedTick(() => fixedCount += 1)
                .DoLateTick (() => lateCount += 1)
                .WithId(1);

            var state2 = StateMachine.FunctionalState()
                .EnterWhen(() => count == 5)
                .ExitWhen (() => count >= 10)
                .DoTick(() => count += 1)
                .WithId(2);

            var machine = StateMachine.MultiEntrance()
                .WithStates(state1, state2)
                .WithId(machineId);

            Assert.AreNotEqual(IState.Default, machine.Current);
            Assert.AreEqual(machineId, machine.Identity);
            Assert.AreEqual(true, machine.HasChild);
            Assert.AreEqual(2, machine.States.Count());
            Assert.IsTrue(machine.States.Contains(state1));
            Assert.IsTrue(machine.States.Contains(state2));

            for (var i = 0; i <= 15; i++)
            {
                var transfered = machine.Transfer();

                machine.Tick();
                machine.FixedTick();
                machine.LateTick();

                //Debug.Log(string.Format("{0} {1} {2}", transfered, i, count));
                
                Assert.AreEqual(transfered, i < 9);
                Assert.AreEqual(fixedCount, i < 6 ? i + 1 : 6);
                Assert.AreEqual(lateCount , i < 6 ? i + 1 : 6);

                if (i <  5) { Assert.AreEqual(count, i + 1); }
                if (i == 5) { Assert.AreEqual(count, i + 1 + i - 4); }
                if (i >  5 && i <= 8) { Assert.AreEqual(count, i + 1 + 1); }
                if (i >  8) { Assert.AreEqual(count, 10); }
            }

            machine.Dispose();

            Assert.AreNotEqual(machineId, machine.Identity);
            Assert.AreNotEqual(IState.Default, machine.Current);
            Assert.AreEqual(false, machine.HasChild);
            Assert.AreEqual(0, machine.States.Count());
            Assert.IsFalse(machine.States.Contains(state1));
            Assert.IsFalse(machine.States.Contains(state2));
        }
    }
}
