using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX.Internal
{
    internal class MachineCollection
    {
        internal enum UpdateType 
        {
            Transfer    = 0,
            Update      = 1,
            FixedUpdate = 2,
            LateUpdate  = 3,
        }

        public MachineCollection(UpdateType updateType) 
        {
            if (updateType == UpdateType.Transfer) 
            {
                IsTicked = Transfer;
            }

            if (updateType == UpdateType.Update) 
            {
                IsTicked = Tick;
            }

            else if (updateType == UpdateType.FixedUpdate)
            {
                IsTicked = FixedTick;
            }

            else if (updateType == UpdateType.LateUpdate)
            {
                IsTicked = LateTick;
            }
        }

        private object _CollectionLock = new object();

        private List<IMachineRegistration>  _Registrations = new();
        private Queue<IMachineRegistration> _Await   = new();

        private Func<IMachineRegistration, bool> IsTicked;

        public int ThreadCount      => _Registrations.Count;
        public int ValidThreadCount => _Registrations.Count(t => t.IsValid);

        public void Register(IMachineRegistration registration) 
        {
            lock (_CollectionLock) 
            {
                _Await.Enqueue(registration);
            }
        }

        public bool Tick() 
        {
            _Registrations = CheckValid().ToList();

            return _Registrations.Any();
        }

        private IEnumerable<IMachineRegistration> CheckValid() 
        {
            var hashset = new HashSet<IMachineRegistration>();

            foreach (var registration in _Registrations) 
            {
                if (!hashset.Add(registration)) 
                {
                    continue;
                }

                if (IsTicked(registration)) 
                {
                    yield return registration;
                }
            }

            for (; _Await.Any();) 
            {
                var registration = _Await.Dequeue();

                if (!hashset.Add(registration))
                {
                    continue;
                }

                if (IsTicked(registration)) 
                {
                    yield return registration;
                }
            }
        }

        private bool Transfer(IMachineRegistration registration) 
        {
            var valid = registration.IsValid && registration.Transfer;

            if (!valid)
            {
                registration.Dispose();
            }

            return valid;
        }

        private bool Tick(IMachineRegistration registration) 
        {
            var valid = registration.IsUpdate;

            if (valid) 
            {
                registration.Machine?.Tick();
            }

            return valid;
        }

        private bool FixedTick(IMachineRegistration registration)
        {
            var valid = registration.IsFixedUpdate;

            if (valid)
            {
                registration.Machine?.FixedTick();
            }

            return valid;
        }

        private bool LateTick(IMachineRegistration registration)
        {
            var valid = registration.IsLateUpdate;

            if (valid)
            {
                registration.Machine?.LateTick();
            }

            return valid;
        }
    }
}
