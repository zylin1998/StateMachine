using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public class ExpandStateMachine : IStateMachine, IWrappableMachine
    {
        public ExpandStateMachine() : this(new SingleEntrance()) 
        {

        }

        public ExpandStateMachine(IStateMachine core) : this(core, StateMachine.Identity.ExpandStatemachine)
        {
            
        }

        public ExpandStateMachine(IStateMachine core, object id)
        {
            Core = core;

            Identity = id;
        }

        public bool ForceExit { get; set; }

        public IStateMachine Core { get; private set; }

        public object Identity { get => Core.Identity; private set => SetIdentity(value); }

        public IState Current => Core.Current;

        public IEnumerable<IState> States => Core.States;

        public virtual bool HasChild => Core.HasChild;

        public INodeWatcher Watcher { get => Core.Watcher; set => Core.Watcher = value; }

        public virtual void SetCore(IStateMachine machine) 
        {
            Core = machine;
        }

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

        public void SetIdentity(object identity) 
        {
            Core.SetIdentity(identity);
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

        public virtual void Reset() 
        {
            Core.Reset();
        }

        public virtual void Dispose(bool disposeChild) 
        {
            Core.Dispose(disposeChild);
            
            Core.Recycle();

            SetIdentity(StateMachine.Identity.ExpandStatemachine);
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }
    }
}
