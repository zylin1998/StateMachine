using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX
{
    public interface IDisposableCatcher 
    {
        public void Add(IMachineRegistration registration);

        public void Remove(IMachineRegistration registration);
    }

    internal class DisposableCatcher : MonoBehaviour, IDisposableCatcher
    {
        private HashSet<IMachineRegistration> _Registrations = new HashSet<IMachineRegistration>();

        public void Add(IMachineRegistration registration)
        {
            if (_Registrations.Add(registration))
            {
                registration.DisposableCatcher = this;
            }
        }

        public void Remove(IMachineRegistration registration) 
        {
            if (_Registrations.Remove(registration)) 
            {
                registration.DisposableCatcher = default;
            }
        }

        private void OnDestroy()
        {
            foreach (var registration in _Registrations) 
            {
                registration.Dispose();
            }
        }
    }
}
