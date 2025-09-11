using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    internal class MultiEntrance : IStateMachine
    {
        internal class MultiState : IState
        {
            public object Identity { get; } = StateMachine.Identity.MultiEntrance;

            private HashSet<IState> _States = new();

            public bool Enter { get; } = true;
            public bool Exit  { get; } = false;

            public bool HasChild { get; }

            private bool _HasExit = false;
            private bool _IsPhase = false;

            public bool Add(IState state) 
            {
                var result = _States.Add(state);

                if (result)
                {
                    state.OnEnter();
                }

                return result;
            }

            public bool Transfer() 
            {
                _HasExit = false;
                _IsPhase = false;

                _States = Check().ToHashSet();

                return _HasExit || _IsPhase;
            }

            public void Tick()
            {
                foreach (var state in _States) 
                {
                    state.Tick();
                }
            }

            public void FixedTick()
            {
                foreach (var state in _States)
                {
                    state.FixedTick();
                }
            }

            public void LateTick()
            {
                foreach (var state in _States)
                {
                    state.LateTick();
                }
            }

            public void OnEnter()
            {
                //no use
            }

            public void OnExit()
            {
                //no use
            }

            private IEnumerable<IState> Check() 
            {
                foreach (var state in _States) 
                {
                    if (state.Exit)
                    {
                        state.OnExit();

                        _HasExit = true;

                        continue;
                    }

                    if (state.HasChild && state is IStateMachine machine) 
                    {
                        _IsPhase = _IsPhase || machine.Transfer();
                    }

                    yield return state;
                }
            }

            public void Dispose()
            {
                _States.Clear();
            }

            public void SetIdentity(object identity)
            {
                //No Use
            }
        }

        private List<IState> _States = new();
        private MultiState   _State  = new();

        public IState Current => _State;

        public IEnumerable<IState> States => _States;

        public bool ForceExit { get; set; }

        public object Identity { get; protected set; } = "Multi Entrance";

        public bool HasChild => States.Any();

        public void Add(IState state)
        {
            _States.Add(state);
        }

        public void Set(IState state)
        {
            _State.Add(state);
        }

        public void Set(object identity)
        {
            var state = _States.Find(s => Equals(s, identity));

            Set(state);
        }

        public void SetIdentity(object identity) 
        {
            Identity = identity;
        }

        public bool Transfer()
        {
            var enter = _States.FindAll(s => s.Enter);
            
            enter.ForEach(s => Set(s));

            return _State.Transfer() || enter.Count > 0;
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
            _State.Dispose();

            foreach (var state in States)
            {
                state.Dispose();
            }
        }
    }
}
