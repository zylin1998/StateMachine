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

        private bool _QueryLock = false;

        private Queue<IMachineRegistration> _AwaitRemove = new Queue<IMachineRegistration>();

        public void Add(IMachineRegistration registration)
        {
            if (_Registrations.Add(registration))
            {
                registration.DisposableCatcher = this;
            }
        }

        public void Remove(IMachineRegistration registration) 
        {
            if (_QueryLock)
            {
                _AwaitRemove.Enqueue(registration);
            }
            else 
            {
                if (_Registrations.Remove(registration))
                {
                    registration.DisposableCatcher = default;
                }
            }
        }

        private void OnDestroy()
        {
            if (!StateMachine.GetInternalRoot()) 
            {
                return;
            }

            _QueryLock = true;
            
            foreach (var registration in _Registrations)
            {
                registration.Dispose();

                registration.Machine.Recycle();
            }

            _QueryLock = false;

            for (; _AwaitRemove.Any();) 
            {
                Remove(_AwaitRemove.Dequeue());
            }
        }
    }
}
