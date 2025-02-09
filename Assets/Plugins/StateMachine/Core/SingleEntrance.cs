using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    internal class SingleEntrance : IStateMachine
    {
        protected List<IState> _States = new();

        public IState Current { get; private set; } = IState.Default;

        public IEnumerable<IState> States => _States;

        public bool ForceExit { get; set; }

        public void Add(IState state) 
        {
            _States.Add(state);
        }

        public void Set(IState state) 
        {
            if (Equals(state, Current)) { return; }

            Current.OnExit();

            Current = state;

            Current.OnEnter();
        }

        public void Set(object identity) 
        {
            var next = States.FirstOrDefault(s => Equals(s.Identity, identity));

            if (next == default) { return; }

            Set(next);
        }

        public bool Transfer() 
        {
            if (!Current.Exit && !ForceExit) { return CheckPhase(); }

            var next = States.FirstOrDefault(s => s != Current && s.Enter) ?? IState.Default;

            Set(next);

            return CheckPhase() || !Equals(Current, IState.Default);
        }

        public void Tick() 
        {
            Current.Tick();
        }

        public void FixedTick()
        {
            Current.FixedTick();
        }

        public void LateTick()
        {
            Current.LateTick();
        }

        public void Dispose() 
        {
            Set(IState.Default);

            foreach (var state in States)
            {
                if (state is IStateMachine machine)
                {
                    machine.Dispose();
                }
            }
        }

        private bool CheckPhase() 
        {
            return Current is IStateMachine machine ? machine.Transfer() : false;
        }
    }
}
