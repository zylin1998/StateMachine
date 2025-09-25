using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    internal class SingleEntrance : IStateMachine
    {
        protected List<IState> _States = new();

        public object Identity { get; private set; } = StateMachine.Identity.SingleEntrance;

        public IState Current { get; private set; } = IState.Default;

        public bool ForceExit { get; set; }

        public IEnumerable<IState> States => _States;

        public bool HasChild => States.Any();

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

        public void SetIdentity(object identity) 
        {
            Identity = identity; ;
        }

        public bool Transfer() 
        {
            if (Current.Exit || ForceExit) 
            {
                var temp = States.SkipWhile((s) => Equals(s, Current)).FirstOrDefault(s => s != Current && s.Enter);

                var next = temp ?? IState.Default;

                Set(next);
            }

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

        public void Reset() 
        {
            Set(IState.Default);

            foreach (var state in States)
            {
                state.Reset();
            }
        }

        public void Dispose(bool disposeChild)
        {
            Set(IState.Default);
            
            if (disposeChild)
            {
                foreach (var state in States)
                {
                    state.Dispose();

                    state.Recycle();
                }
            }

            _States.Clear();

            SetIdentity(StateMachine.Identity.SingleEntrance);
        }

        public void Dispose() 
        {
            Dispose(true);
        }

        private bool CheckPhase() 
        {
            if (Current.HasChild && Current is IStateMachine machine) 
            {
                return machine.Transfer();
            }

            return false;
        }
    }
}
