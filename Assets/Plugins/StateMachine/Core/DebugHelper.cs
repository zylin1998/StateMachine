﻿using System;
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

        public static void LogError(object message)
        {
            Debug.LogError(message);
        }

        public static void LogWarning(object message) 
        {
            Debug.LogWarning(message);
        }
    }
}
