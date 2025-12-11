using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineX
{
    public static class DebugHelper
    {
        public static event Application.LogCallback OnLogRecieve 
        {
            add    => Application.logMessageReceivedThreaded += value;

            remove => Application.logMessageReceivedThreaded -= value;
        }

        public static void Log(object message) 
        {
            Debug.Log(message);
        }

        public static void Log(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        public static void LogError(object message)
        {
            Debug.LogError(message);
        }

        public static void LogError(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        public static void LogWarning(object message) 
        {
            Debug.LogWarning(message);
        }

        public static void LogWarning(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        public static void LogException(Exception exception) 
        {
            Debug.LogException(exception);
        }

        public static void LogException(Exception exception, UnityEngine.Object context)
        {
            Debug.LogException(exception, context);
        }

        public static void Assert(bool condition)
        {
            Debug.Assert(condition);
        }

        public static void Assert(bool condition, object message) 
        {
            Debug.Assert(condition, message);
        }

        public static void Assert(bool condition, string format, params object[] args)
        {
            Debug.AssertFormat(condition, format, args);
        }
    }
}
