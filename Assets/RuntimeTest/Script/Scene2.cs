using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.RuntimeTest
{
    public class Scene2 : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log(StateMachine.Monitor.UpdateValidThreadCount);
        }
    }
}
