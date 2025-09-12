using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.Internal
{
    internal class MainThreadDispatcher : MonoBehaviour
    {
        public static MainThreadDispatcher _Instance;

        public static MainThreadDispatcher Instance 
        {
            get 
            {
                Initialize();

                return _Instance;
            }
        }

        private void Awake()
        {
            if (_Instance != null && _Instance != this) 
            {
                Destroy(this);

                return;
            }

            if (_Instance == null)
            {
                _Instance = this;

                DontDestroyOnLoad(this);

                _TransferCollection    = new(MachineCollection.UpdateType.Transfer);
                _UpdateCollection      = new(MachineCollection.UpdateType.Update);
                _FixedUpdateCollection = new(MachineCollection.UpdateType.FixedUpdate);
                _LateUpdateCollection  = new(MachineCollection.UpdateType.LateUpdate);
            }
        }

        private void OnDestroy()
        {
            if (Equals(_Instance, this))
            {
                _Instance = null;
            }
        }

        private HashSet<IMachineRegistration> _Registrations = new();

        private MachineCollection _TransferCollection;
        private MachineCollection _UpdateCollection;
        private MachineCollection _FixedUpdateCollection;
        private MachineCollection _LateUpdateCollection;

        private Coroutine _Tansfer;
        private Coroutine _Update;
        private Coroutine _FixedUpdate;
        private Coroutine _LateUpdate;

        private IEnumerator TransferCoroutine() 
        {
            for (; _TransferCollection.Tick();)
            {
                _Registrations = _Registrations
                    .Where(r => r.IsValid)
                    .ToHashSet();

                yield return null;
            }
            
            _Tansfer = default;
        }

        private IEnumerator UpdateCoroutine() 
        {
            for(; _UpdateCollection.Tick();) 
            {
                yield return null;
            }

            _Update = default;
        }

        private IEnumerator FixedUpdateCoroutine()
        {
            for (; _FixedUpdateCollection.Tick();)
            {
                yield return new WaitForFixedUpdate();
            }

            _FixedUpdate = default;
        }

        private IEnumerator LateUpdateCoroutine()
        {
            for (; _LateUpdateCollection.Tick();)
            {
                yield return new WaitForEndOfFrame();
            }

            _LateUpdate = null;
        }

        private IMachineRegistration InternalGetRegistration(IStateMachine machine) 
        {
            var registraion = _Registrations.FirstOrDefault(r => Equals(r.Machine, machine));

            if (registraion != null) 
            {
                return registraion;
            }

            registraion = new MachineRegistration(machine);

            _Registrations.Add(registraion);

            _TransferCollection.Register(registraion);

            return registraion;
        }

        public static void Initialize() 
        {
            if (_Instance) { return; }

            var dispatcher = default(MainThreadDispatcher);
            
            if (!dispatcher)
            {
                dispatcher = FindObjectOfType<MainThreadDispatcher>();
            }

            if (!dispatcher)
            {
                dispatcher = new GameObject("StateMachine").AddComponent<MainThreadDispatcher>();
            }

            else 
            {
                dispatcher.Awake();
            }
        }

        public static int UpdateThreadCount      => Instance._UpdateCollection.ThreadCount;
        public static int FixedUpdateThreadCount => Instance._FixedUpdateCollection.ThreadCount;
        public static int LateUpdateThreadCount  => Instance._LateUpdateCollection.ThreadCount;

        public static int UpdateValidThreadCount      => Instance._UpdateCollection.ValidThreadCount;
        public static int FixedUpdateValidThreadCount => Instance._FixedUpdateCollection.ValidThreadCount;
        public static int LateUpdateValidThreadCount  => Instance._LateUpdateCollection.ValidThreadCount;

        internal static IMachineRegistration GetRegistration(IStateMachine machine) 
        {
            return Instance.InternalGetRegistration(machine);
        }

        public static IMachineRegistration RegisterUpdate(IStateMachine machine) 
        {
            return RegisterUpdate(GetRegistration(machine));
        }

        public static IMachineRegistration RegisterFixedUpdate(IStateMachine machine)
        {
            return RegisterFixedUpdate(GetRegistration(machine));
        }

        public static IMachineRegistration RegisterLateUpdate(IStateMachine machine)
        {
            return RegisterLateUpdate(GetRegistration(machine));
        }

        public static IMachineRegistration RegisterUpdate(IMachineRegistration registration) 
        {
            registration.IsUpdate = true;

            Instance._UpdateCollection.Register(registration);

            if (Instance._Update == default) 
            {
                Instance._Update = Instance.StartCoroutine(Instance.UpdateCoroutine());
            }

            if (Instance._Tansfer == default) 
            {
                Instance._Tansfer = Instance.StartCoroutine(Instance.TransferCoroutine());
            }

            return registration;
        }

        public static IMachineRegistration RegisterFixedUpdate(IMachineRegistration registration)
        {
            registration.IsFixedUpdate = true;

            Instance._FixedUpdateCollection.Register(registration);

            if (Instance._FixedUpdate == default)
            {
                Instance._FixedUpdate = Instance.StartCoroutine(Instance.FixedUpdateCoroutine());
            }

            if (Instance._Tansfer == default)
            {
                Instance._Tansfer = Instance.StartCoroutine(Instance.TransferCoroutine());
            }

            return registration;
        }

        public static IMachineRegistration RegisterLateUpdate(IMachineRegistration registration)
        {
            registration.IsLateUpdate = true;

            Instance._LateUpdateCollection.Register(registration);

            if (Instance._LateUpdate == default)
            {
                Instance._LateUpdate = Instance.StartCoroutine(Instance.LateUpdateCoroutine());
            }

            if (Instance._Tansfer == default)
            {
                Instance._Tansfer = Instance.StartCoroutine(Instance.TransferCoroutine());
            }

            return registration;
        }
    }
}
