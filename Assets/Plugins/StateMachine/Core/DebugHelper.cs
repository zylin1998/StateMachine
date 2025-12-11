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
    }
}
