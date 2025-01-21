using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "PhaseStateMachine Asset", menuName = "StateMachine/PhaseStateMachine Asset", order = 1)]
    public class PhaseStateMachineAsset : StateAssetBase, IStateMachineAsset
    {
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private bool _Cycle;
        [SerializeField]
        private bool _IgnoreEnter;
        [SerializeField]
        private List<string> _Orders;

        public virtual IStateMachine GetMachine()
        {
            return CreateMachine();
        }

        public override IState GetState()
        {
            return CreateMachine();
        }

        protected virtual IPhaseStateMachine CreateMachine()
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState()));

            if (_Sequence) 
            { 
                var sequence = machine.Sequence().OrderBy(_Orders);

                sequence.Cycle = _Cycle;
                sequence.IgnoreEnter = _IgnoreEnter;

                return sequence.Phase();
            }

            return machine.Phase();
        }
    }

    public class PhaseStateMachineAsset<T> : StateAssetBase<T>, IStateMachineAsset<T>
    {
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private bool _Cycle;
        [SerializeField]
        private bool _IgnoreEnter;
        [SerializeField]
        private List<string> _Orders;

        public virtual IStateMachine GetMachine(T param)
        {
            return CreateMachine(param);
        }

        public override IState GetState(T param)
        {
            return CreateMachine(param);
        }

        protected virtual IPhaseStateMachine CreateMachine(T param)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param)));

            if (_Sequence)
            {
                var sequence = machine.Sequence().OrderBy(_Orders);

                sequence.Cycle = _Cycle;
                sequence.IgnoreEnter = _IgnoreEnter;

                return sequence.Phase();
            }

            return machine.Phase();
        }
    }

    public class PhaseStateMachineAsset<T1, T2> : StateAssetBase<T1, T2>, IStateMachineAsset<T1, T2>
    {
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T1, T2>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private bool _Cycle;
        [SerializeField]
        private bool _IgnoreEnter;
        [SerializeField]
        private List<string> _Orders;

        public virtual IStateMachine GetMachine(T1 param1, T2 param2)
        {
            return CreateMachine(param1, param2);
        }

        public override IState GetState(T1 param1, T2 param2)
        {
            return CreateMachine(param1, param2);
        }

        protected virtual IPhaseStateMachine CreateMachine(T1 param1, T2 param2)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param1, param2)));

            if (_Sequence)
            {
                var sequence = machine.Sequence().OrderBy(_Orders);

                sequence.Cycle = _Cycle;
                sequence.IgnoreEnter = _IgnoreEnter;

                return sequence.Phase();
            }

            return machine.Phase();
        }
    }

    public class PhaseStateMachineAsset<T1, T2, T3> : StateAssetBase<T1, T2, T3>, IStateMachineAsset<T1, T2, T3>
    {
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T1, T2, T3>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private bool _Cycle;
        [SerializeField]
        private bool _IgnoreEnter;
        [SerializeField]
        private List<string> _Orders;

        public virtual IStateMachine GetMachine(T1 param1, T2 param2, T3 param3)
        {
            return CreateMachine(param1, param2, param3);
        }

        public override IState GetState(T1 param1, T2 param2, T3 param3)
        {
            return CreateMachine(param1, param2, param3);
        }

        protected virtual IPhaseStateMachine CreateMachine(T1 param1, T2 param2, T3 param3)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param1, param2, param3)));

            if (_Sequence)
            {
                var sequence = machine.Sequence().OrderBy(_Orders);

                sequence.Cycle = _Cycle;
                sequence.IgnoreEnter = _IgnoreEnter;

                return sequence.Phase();
            }

            return machine.Phase();
        }
    }

    public class PhaseStateMachineAsset<T1, T2, T3, T4> : StateAssetBase<T1, T2, T3, T4>, IStateMachineAsset<T1, T2, T3, T4>
    {
        [SerializeField]
        internal MachineType _MachineType;
        [SerializeField]
        protected List<StateAssetBase<T1, T2, T3, T4>> _States;
        [SerializeField]
        private bool _Sequence;
        [SerializeField]
        private bool _Cycle;
        [SerializeField]
        private bool _IgnoreEnter;
        [SerializeField]
        private List<string> _Orders;

        public virtual IStateMachine GetMachine(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            return CreateMachine(param1, param2, param3, param4);
        }

        public override IState GetState(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            return CreateMachine(param1, param2, param3, param4);
        }

        protected virtual IPhaseStateMachine CreateMachine(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var machine =
                _MachineType == MachineType.SingleEntrance ? StateMachine.SingleEntrance() : StateMachine.MultiEntrance();

            machine.WithStates(_States.Select(s => s.GetState(param1, param2, param3, param4)));

            if (_Sequence)
            {
                var sequence = machine.Sequence().OrderBy(_Orders);

                sequence.Cycle = _Cycle;
                sequence.IgnoreEnter = _IgnoreEnter;

                return sequence.Phase();
            }

            return machine.Phase();
        }
    }
}