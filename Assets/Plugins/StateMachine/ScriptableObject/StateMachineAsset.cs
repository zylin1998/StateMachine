﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "StateMachine Asset", menuName = "StateMachine/StateMachine Asset", order = 1)]
    public class StateMachineAsset : ScriptableObject, IStateMachineAsset
    {
        [SerializeField]
        protected string      _Id;
        [SerializeField]
        internal  MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private List<string> _Orders;

        public object Id => _Id;

        public IStateMachine GetMachine()
        {
            var machine = 
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState()));

            return !_Sequence ? machine : machine.Sequence().OrderBy(_Orders);
        }
    }

    public class StateMachineAsset<T> : ScriptableObject, IStateMachineAsset<T>
    {
        [SerializeField]
        protected string      _Id;
        [SerializeField]
        internal  MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private List<string> _Orders;

        public object Id => _Id;

        public IStateMachine GetMachine(T param)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param)));

            return !_Sequence ? machine : machine.Sequence().OrderBy(_Orders);
        }
    }

    public class StateMachineAsset<T1, T2> : ScriptableObject, IStateMachineAsset<T1, T2>
    {
        [SerializeField]
        protected string _Id;
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T1, T2>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private List<string> _Orders;

        public object Id => _Id;

        public IStateMachine GetMachine(T1 param1, T2 param2)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param1, param2)));

            return !_Sequence ? machine : machine.Sequence().OrderBy(_Orders);
        }
    }

    public class StateMachineAsset<T1, T2, T3> : ScriptableObject, IStateMachineAsset<T1, T2, T3>
    {
        [SerializeField]
        protected string _Id;
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T1, T2, T3>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private List<string> _Orders;

        public object Id => _Id;

        public IStateMachine GetMachine(T1 param1, T2 param2, T3 param3)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param1, param2, param3)));

            return !_Sequence ? machine : machine.Sequence().OrderBy(_Orders);
        }
    }

    public class StateMachineAsset<T1, T2, T3, T4> : ScriptableObject, IStateMachineAsset<T1, T2, T3, T4>
    {
        [SerializeField]
        protected string _Id;
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T1, T2, T3, T4>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private List<string> _Orders;

        public object Id => _Id;

        public IStateMachine GetMachine(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param1, param2, param3, param4)));

            return !_Sequence ? machine : machine.Sequence().OrderBy(_Orders);
        }
    }
}
