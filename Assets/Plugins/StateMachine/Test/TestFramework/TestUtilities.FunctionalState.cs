using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StateMachineX.TestFramework
{
    public static partial class TestUtilities
    {
        public static IFunctionalState FillUp(this IFunctionalState self)
        {
            return self
                .EnterWhen(FalseCondition)
                .ExitWhen(TrueCondition)
                .DoOnEnter(Callback)
                .DoOnExit(Callback)
                .DoTick(Callback)
                .DoFixedTick(Callback)
                .DoLateTick(Callback);
        }

        public static IFunctionalState<T1> FillUp<T1>(this IFunctionalState<T1> self)
        {
            return self
                .EnterWhen(FalseCondition)
                .ExitWhen(TrueCondition)
                .DoOnEnter(Callback)
                .DoOnExit(Callback)
                .DoTick(Callback)
                .DoFixedTick(Callback)
                .DoLateTick(Callback);
        }

        public static IFunctionalState<T1, T2> FillUp<T1, T2>(this IFunctionalState<T1, T2> self)
        {
            return self
                .EnterWhen(FalseCondition)
                .ExitWhen(TrueCondition)
                .DoOnEnter(Callback)
                .DoOnExit(Callback)
                .DoTick(Callback)
                .DoFixedTick(Callback)
                .DoLateTick(Callback);
        }

        public static IFunctionalState<T1, T2, T3> FillUp<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self)
        {
            return self
                .EnterWhen(FalseCondition)
                .ExitWhen(TrueCondition)
                .DoOnEnter(Callback)
                .DoOnExit(Callback)
                .DoTick(Callback)
                .DoFixedTick(Callback)
                .DoLateTick(Callback);
        }

        public static IFunctionalState<T1, T2, T3, T4> FillUp<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self)
        {
            return self
                .EnterWhen(FalseCondition)
                .ExitWhen(TrueCondition)
                .DoOnEnter(Callback)
                .DoOnExit(Callback)
                .DoTick(Callback)
                .DoFixedTick(Callback)
                .DoLateTick(Callback);
        }

        public static void AssertNoParameters<T1>(IFunctionalState<T1> state) 
        {
            Assert.IsTrue(state.Param1 == null);
        }

        public static void AssertNoParameters<T1, T2>(IFunctionalState<T1, T2> state)
        {
            Assert.IsTrue(state.Param1 == null);
            Assert.IsTrue(state.Param2 == null);
        }

        public static void AssertNoParameters<T1, T2, T3>(IFunctionalState<T1, T2, T3> state)
        {
            Assert.IsTrue(state.Param1 == null);
            Assert.IsTrue(state.Param2 == null);
            Assert.IsTrue(state.Param3 == null);
        }

        public static void AssertNoParameters<T1, T2, T3, T4>(IFunctionalState<T1, T2, T3, T4> state)
        {
            Assert.IsTrue(state.Param1 == null);
            Assert.IsTrue(state.Param2 == null);
            Assert.IsTrue(state.Param3 == null);
            Assert.IsTrue(state.Param4 == null);
        }
    }
}
