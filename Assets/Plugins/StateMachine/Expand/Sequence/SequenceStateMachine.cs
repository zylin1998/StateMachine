using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX
{
    internal class SequenceStateMachine : ExpandStateMachine, ISequenceStateMachine
    {
        public SequenceStateMachine() : base()
        {

        }

        public SequenceStateMachine(IStateMachine core) : base(MachineCheck(core), StateMachine.Identity.SequenceStatemachine)
        {

        }

        public SequenceStateMachine(IStateMachine core, object identity) : base(MachineCheck(core), identity)
        {

        }

        private ISequenceOrder _Order;
        private IState[] _OrderedStates;
        private int _Flag = -1;

        public bool Cycle { get; set; }

        public bool Active
        {
            get
            {
                if (Cycle) { return true; }

                if (_Flag < _OrderedStates.Length - 1) { return true; }

                return !Current.Exit;
            }
        }

        public bool IgnoreEnter { get; set; } = true;

        public void OrderBy(ISequenceOrder order)
        {
            _Order = order;

            _OrderedStates = Ordered().ToArray();
        }

        public override void Add(IState state)
        {
            base.Add(state);

            _OrderedStates = Ordered().ToArray();
        }

        public override bool Transfer()
        {
            var notDefault = !Equals(Current, IState.Default);

            if (Current.Exit || ForceExit) 
            {
                var next = IState.Default;

                next = IgnoreEnter ? GetNext() : FindCanEnter();

                var transfered = !Equals(next, IState.Default) && !Equals(next, Current);

                Set(next);

                return transfered || notDefault;
            }

            return CheckPhase() || notDefault;
        }

        public override void Reset()
        {
            _Flag = -1;

            base.Reset();
        }

        public override void Dispose()
        {
            Reset();

            base.Dispose();
        }

        protected IEnumerable<IState> Ordered() 
        {
            if (_Order == default) 
            {
                foreach (var state in States) 
                {
                    yield return state;
                }
            }

            var dic = States.ToDictionary(s => s.Identity);

            foreach (var id in _Order.Orders) 
            {
                if (dic.TryGetValue(id, out var state)) 
                {
                    yield return state;
                }
            }
        }

        private bool CheckPhase()
        {
            return Current is IStateMachine machine ? machine.Transfer() : false;
        }

        protected static IStateMachine MachineCheck(IStateMachine machine) 
        {
            if (machine is MultiEntrance multi) 
            {
                Debug.LogWarning("Sequence StateMachine does not support MultiEntrance, will force to turn into SingleEntrance");

                return StateMachine.SingleEntrance()
                    .WithStates(multi.States);
            }

            return machine;
        }

        protected IState GetNext() 
        {
            _Flag++;

            if (_Flag >= _OrderedStates.Length)
            {
                if (Cycle) { _Flag = 0; }

                else
                {
                    return IState.Default;
                }
            }

            return _OrderedStates[_Flag];
        }

        protected IState FindCanEnter() 
        {
            var lastFlag = _Flag;

            for (var index = 0; index < _OrderedStates.Length; index++) 
            {
                var flag = index + _Flag + 1;
                
                flag = flag < _OrderedStates.Length ? flag : flag - _OrderedStates.Length;

                var state = _OrderedStates[flag];

                if (flag == _Flag) { return state; }
                if (!state.Enter)  { continue; }
                
                if (flag <  _Flag && !Cycle) { break; }
                if (flag != _Flag )          
                {
                    _Flag = flag;

                    return state; 
                }
            }

            return IState.Default;
        }
    }
}
