using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using StateMachineX.TestFramework;

namespace StateMachineX.UnitTest
{
    public class NodePoolTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void StateNodeSpawnTest()
        {
            var param1 = new Parameter();
            var param2 = new Parameter();
            var param3 = new Parameter();
            var param4 = new Parameter();

            var state0 = NodePool.GetFunctionalState().FillUp();
            var state1 = NodePool.GetFunctionalState(param1).FillUp();
            var state2 = NodePool.GetFunctionalState(param1, param2).FillUp();
            var state3 = NodePool.GetFunctionalState(param1, param2, param3).FillUp();
            var state4 = NodePool.GetFunctionalState(param1, param2, param3, param4).FillUp();

            Assert.IsNotNull(state0);
            Assert.IsNotNull(state1);
            Assert.IsNotNull(state2);
            Assert.IsNotNull(state3);
            Assert.IsNotNull(state4);

            NodePool.Despawn(state0);
            NodePool.Despawn(state1);
            NodePool.Despawn(state2);
            NodePool.Despawn(state3);
            NodePool.Despawn(state4);

            TestUtilities.AssertNoParameters(state1);
            TestUtilities.AssertNoParameters(state2);
            TestUtilities.AssertNoParameters(state3);
            TestUtilities.AssertNoParameters(state4);
        }

        [Test]
        public void StateMachineSpawnTest() 
        {
            var single = NodePool.GetSingleEntrance();
            var multi  = NodePool.GetMultiEntrance();

            Assert.IsNotNull(single);
            Assert.IsNotNull(multi);
        }

        [Test]
        public void ExpandStateMachineSpawnTest()
        {

        }
    }
}
