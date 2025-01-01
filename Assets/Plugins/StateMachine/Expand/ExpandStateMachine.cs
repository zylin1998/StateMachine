using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    public class ExpandStateMachine : IStateMachine
    {
        public ExpandStateMachine() : this(new SingleEntrance()) 
        {

        }

        public ExpandStateMachine(IStateMachine core)
        {
            Core = core;
        }

        protected IStateMachine Core { get; }

        public IState Current => Core.Current;

        public IEnumerable<IState> States => Core.States;

        public bool ForceExit { get; set; }

        public virtual void Add(IState state) 
        {
            Core.Add(state);
        }

        public void Set(IState state) 
        {
            Core.Set(state);
        }

        public void Set(object identity)
        {
            Core.Set(identity);
        }

        public virtual bool Transfer() 
        {
            var result = Core.Transfer();

            if (Current is IStateMachine machine) 
            {
                result = result || machine.Transfer(); 
            }

            return result;
        }

        public void Tick() 
        {
            Core.Tick();
        }

        public void FixedTick()
        {
            Core.FixedTick();
        }

        public void LateTick()
        {
            Core.LateTick();
        }

        public virtual void Dispose()
        {
            Core.Dispose();

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
