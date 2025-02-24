using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    internal class MultiEntrance : IStateMachine
    {
        private class MultiState : IState
        {
            public object Identity { get; } = "MultiEntrance";

            private HashSet<IState> _States = new();

            public bool Enter { get; } = true;
            public bool Exit  { get; } = false;

            private bool _HasExit = false;
            private bool _IsPhase = false;

            public void Add(IState state) 
            {
                state.OnEnter();

                _States.Add(state);
            }

            public void Clear() 
            {
                _States.Clear();
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

                    if (state is IStateMachine machine) 
                    {
                        _IsPhase = _IsPhase || machine.Transfer();
                    }

                    yield return state;
                }
            }

            private IEnumerable<IState> IsPhase(IEnumerable<IState> states) 
            {
                foreach (var state in _States)
                {
                    if (state is IStateMachine machine)
                    {
                        _IsPhase = _IsPhase || machine.Transfer();
                    }

                    yield return state;
                }
            }
        }

        private List<IState> _States = new();
        private MultiState   _State  = new();

        public IState Current => _State;

        public IEnumerable<IState> States => _States;

        public bool ForceExit { get; set; }

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
            _State.Clear();

            foreach (var state in States)
            {
                if (state is IStateMachine machine)
                {
                    machine.Dispose();
                }
            }
        }
    }
}
