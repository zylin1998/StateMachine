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

            var state0 = PoolUtils.GetFunctionalState().FillUp();
            var state1 = PoolUtils.GetFunctionalState(param1).FillUp();
            var state2 = PoolUtils.GetFunctionalState(param1, param2).FillUp();
            var state3 = PoolUtils.GetFunctionalState(param1, param2, param3).FillUp();
            var state4 = PoolUtils.GetFunctionalState(param1, param2, param3, param4).FillUp();

            Assert.IsNotNull(state0);
            Assert.IsNotNull(state1);
            Assert.IsNotNull(state2);
            Assert.IsNotNull(state3);
            Assert.IsNotNull(state4);

            PoolUtils.Despawn(state0);
            PoolUtils.Despawn(state1);
            PoolUtils.Despawn(state2);
            PoolUtils.Despawn(state3);
            PoolUtils.Despawn(state4);

            TestUtilities.AssertNoParameters(state1);
            TestUtilities.AssertNoParameters(state2);
            TestUtilities.AssertNoParameters(state3);
            TestUtilities.AssertNoParameters(state4);
        }

        [Test]
        public void StateMachineSpawnTest() 
        {
            var single = PoolUtils.GetSingleEntrance();
            var multi  = PoolUtils.GetMultiEntrance();

            Assert.IsNotNull(single);
            Assert.IsNotNull(multi);
        }

        [Test]
        public void ExpandStateMachineSpawnTest()
        {

        }
    }
}
