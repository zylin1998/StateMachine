using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    internal class MultiEntrance : IStateMachine
    {
        #region Nest Type

        internal class MultiState : IState, IEnumerable<IState>
        {
            public object Identity { get; } = StateMachine.Identity.MultiEntrance;

            private HashSet<IState> _States = new();

            public bool Enter { get; } = true;
            public bool Exit  { get; } = false;

            public INodeWatcher Watcher { get; set; }

            public bool HasChild => _States.Any();

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
                _States = Check().ToHashSet();
                
                return _States.Count > 0;
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

            public void Reset() 
            {
                _States.Clear();
            }

            public void Dispose(bool disposeChild) 
            {
                Dispose();
            }

            public void Dispose()
            {
                _States.Clear();
            }

            public void SetIdentity(object identity)
            {
                //No Use
            }

            public IEnumerator<IState> GetEnumerator()
            {
                return _States.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private IEnumerable<IState> Check()
            {
                foreach (var state in _States)
                {
                    if (state.Exit)
                    {
                        state.OnExit();

                        continue;
                    }

                    if (state.HasChild && state is IStateMachine machine)
                    {
                        machine.Transfer();
                    }

                    yield return state;
                }
            }
        }

        #endregion

        private List<IState> _States = new();
        private MultiState   _State  = new();

        public bool ForceExit { get; set; }

        public object Identity { get; protected set; } = "Multi Entrance";

        public bool HasChild => States.Any();

        public IState Current => _State;

        public IEnumerable<IState> States => _States;

        public INodeWatcher Watcher { get; set; }

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

            return _State.Transfer();
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
            _State.Reset();

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
    }
}
