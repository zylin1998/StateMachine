using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    internal class DisposableCatcher : MonoBehaviour
    {
        public IDisposable Disposable { get; private set; }

        public void Set(IDisposable disposable) 
        {
            Disposable = disposable;
        }

        private void OnDestroy()
        {
            Disposable?.Dispose();
        }
    }
}
