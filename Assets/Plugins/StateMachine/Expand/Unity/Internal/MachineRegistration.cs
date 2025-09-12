using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IMachineRegistration : IDisposable
    {
        public IStateMachine Machine  { get; }
        public bool          Transfer { get; }
        public bool          IsValid  { get; }

        public bool IsUpdate      { get; set; }
        public bool IsFixedUpdate { get; set; }
        public bool IsLateUpdate  { get; set; }
        
        public IDisposableCatcher DisposableCatcher { get; set; }
    }

    internal class MachineRegistration : IMachineRegistration
    {
        public MachineRegistration(IStateMachine machine) 
        {
            Machine  = machine;
        }

        public IStateMachine Machine  { get; }

        public bool Transfer => Machine?.Transfer() ?? false;
        
        public bool IsValid => CheckValid();

        public bool IsUpdate      { get; set; }
        public bool IsFixedUpdate { get; set; }
        public bool IsLateUpdate  { get; set; }

        public IDisposableCatcher DisposableCatcher { get; set; }
        
        public void Dispose() 
        {
            IsUpdate      = false;
            IsFixedUpdate = false;
            IsLateUpdate  = false;

            DisposableCatcher?.Remove(this);
        }

        private bool CheckValid() 
        {
            if (Machine == null) 
            {
                return false;
            }

            return IsUpdate || IsFixedUpdate || IsLateUpdate;
        }
    }
}
