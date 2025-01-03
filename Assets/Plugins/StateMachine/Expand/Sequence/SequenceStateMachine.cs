﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    internal class SequenceStateMachine : ExpandStateMachine, ISequenceStateMachine
    {
        public SequenceStateMachine() : base() 
        {

        }

        public SequenceStateMachine(IStateMachine core) : base(MachineCheck(core))
        {

        }

        private ISequenceOrder _Order;
        private IState[]       _OrderedStates;
        private int            _Flag = -1;

        public bool Cycle { get; set; }

        public bool Active 
        { 
            get
            {
                if (_Flag < _OrderedStates.Length - 1) { return true; }

                return !Current.Exit;
            } 
        }

        public void OrderBy(ISequenceOrder order)
        {
            _Order = order;

            _OrderedStates = Ordered().ToArray();
        }

        public void Reset()
        {
            _Flag = -1;
        }

        public override void Add(IState state)
        {
            base.Add(state);

            _OrderedStates = Ordered().ToArray();
        }

        public override bool Transfer()
        {
            if (!Current.Exit && !ForceExit) { return false; }

            _Flag++;

            if (_Flag >= _OrderedStates.Length) 
            {
                if (Cycle) { _Flag = 0; }

                else 
                { 
                    Set(IState.Default);

                    return false;
                }
            }

            Set(_OrderedStates[_Flag]);

            return true;
        }

        public override void Dispose()
        {
            Reset();

            base.Dispose();
        }

        protected IEnumerable<IState> Ordered() 
        {
            var dic    = States.ToDictionary(s => s.Identity);
            var orders = _Order != null ? _Order.Orders : States.Select(s => s.Identity);

            foreach (var order in orders) 
            {
                if (dic.TryGetValue(order, out var state)) 
                {
                    yield return state;
                }
            }
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
    }
}
