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

        public static void LogFormat(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        public static void LogError(object message)
        {
            Debug.LogError(message);
        }

        public static void LogErrorFormat(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        public static void LogWarning(object message) 
        {
            Debug.LogWarning(message);
        }

        public static void LogWarningFormat(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }
    }
}
