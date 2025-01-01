using StateMachine.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public static partial class StateMachine
    {
        /*static StateMachine() 
        {
            MainThreadDispatcher.Initialize();
        }*/

        public static class Monitor 
        {
            public static int UpdateThreadCount      => MainThreadDispatcher.UpdateThreadCount;
            public static int FixedUpdateThreadCount => MainThreadDispatcher.FixedUpdateThreadCount;
            public static int LateUpdateThreadCount  => MainThreadDispatcher.LateUpdateThreadCount;

            public static int UpdateValidThreadCount      => MainThreadDispatcher.UpdateValidThreadCount;
            public static int FixedUpdateValidThreadCount => MainThreadDispatcher.FixedUpdateValidThreadCount;
            public static int LateUpdateValidThreadCount  => MainThreadDispatcher.LateUpdateValidThreadCount;
        }
    }
}
