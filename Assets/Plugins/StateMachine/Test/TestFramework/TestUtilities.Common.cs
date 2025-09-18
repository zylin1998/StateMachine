using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StateMachineX.TestFramework
{
    public static partial class TestUtilities
    {
        public static bool FalseCondition() => false;
        public static bool FalseCondition<T1>(T1 param1) => false;
        public static bool FalseCondition<T1, T2>(T1 param1, T2 param2) => false;
        public static bool FalseCondition<T1, T2, T3>(T1 param1, T2 param2, T3 param3) => false;
        public static bool FalseCondition<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4) => false;
        public static bool TrueCondition() => true;
        public static bool TrueCondition<T1>(T1 param1) => true;
        public static bool TrueCondition<T1, T2>(T1 param1, T2 param2) => true;
        public static bool TrueCondition<T1, T2, T3>(T1 param1, T2 param2, T3 param3) => true;
        public static bool TrueCondition<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4) => true;

        public static void Callback() { }
        public static void Callback<T1>(T1 param1) { }
        public static void Callback<T1, T2>(T1 param1, T2 param2) { }
        public static void Callback<T1, T2, T3>(T1 param1, T2 param2, T3 param3) { }
        public static void Callback<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4) { }

    }

    public class Parameter 
    {
        int Data { get; set; }
    }
}
