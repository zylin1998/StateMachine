using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.RuntimeTest
{
    public class Scene2 : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log(StateMachine.Monitor.UpdateValidThreadCount);
        }
    }
}
