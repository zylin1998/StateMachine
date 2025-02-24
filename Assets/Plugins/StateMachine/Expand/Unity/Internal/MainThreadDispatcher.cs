using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.Internal
{
    internal class MainThreadDispatcher : MonoBehaviour
    {
        private static bool initialized;

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
            
                _Update      = new();
                _FixedUpdate = new();
                _LateUpdate  = new();
            }
        }

        private MachineCollection _Update;
        private MachineCollection _FixedUpdate;
        private MachineCollection _LateUpdate;

        private void Update()
        {
            _Update.Tick();
        }

        private void FixedUpdate()
        {
            _FixedUpdate.Tick();
        }

        private void LateUpdate()
        {
            _LateUpdate.Tick();
        }

        private void OnDestroy()
        {
            _Instance = null;
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

        public static int UpdateThreadCount      => Instance._Update.ThreadCount;
        public static int FixedUpdateThreadCount => Instance._FixedUpdate.ThreadCount;
        public static int LateUpdateThreadCount  => Instance._LateUpdate.ThreadCount;

        public static int UpdateValidThreadCount      => Instance._Update.ValidThreadCount;
        public static int FixedUpdateValidThreadCount => Instance._FixedUpdate.ValidThreadCount;
        public static int LateUpdateValidThreadCount  => Instance._LateUpdate.ValidThreadCount;

        public static IDisposable RegisterUpdate(IStateMachine machine, bool transfer) 
        {
            return Instance._Update.Register(new MachineTicker(machine, transfer));
        }

        public static IDisposable RegisterFixedUpdate(IStateMachine machine, bool transfer)
        {
            return Instance._FixedUpdate.Register(new FixedMachineTicker(machine, transfer));
        }

        public static IDisposable RegisterLateUpdate(IStateMachine machine, bool transfer)
        {
            return Instance._LateUpdate.Register(new LateMachineTicker(machine, transfer));
        }
    }
}
