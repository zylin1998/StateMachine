using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace StateMachine
{
    internal interface IMachineTicker : IDisposable
    {
        public IStateMachine Machine  { get; }
        public bool          Transfer { get; }
        public bool          IsValid  { get; }
        public abstract void Tick();
    }

    internal class MachineTicker : IMachineTicker 
    {
        public MachineTicker(IStateMachine machine,  bool transfer) 
        {
            Machine  = machine;
            Transfer = transfer;

            _Scene = SceneManager.GetActiveScene().buildIndex;
        }

        private bool _IsDisposed;
        private int  _Scene;

        public IStateMachine Machine  { get; }
        public bool          Transfer { get; }
        
        public bool IsValid 
            => !_IsDisposed && Machine != null && _Scene == SceneManager.GetActiveScene().buildIndex;

        public void Tick() 
        {
            if (Transfer) Machine.Transfer();

            Machine.Tick();
        }

        public void Dispose() 
        {
            _IsDisposed = true;
        }
    }

    internal class FixedMachineTicker : IMachineTicker
    {
        public FixedMachineTicker(IStateMachine machine, bool transfer)
        {
            Machine  = machine;
            Transfer = transfer;
        }

        private bool _IsDisposed;
        public IStateMachine Machine { get; }
        public bool Transfer { get; }


        public bool IsValid
            => !_IsDisposed && Machine != null;

        public void Tick()
        {
            if (Transfer) Machine.Transfer();

            Machine.FixedTick();
        }

        public void Dispose()
        {
            _IsDisposed = true;
        }
    }

    internal class LateMachineTicker : IMachineTicker
    {
        public LateMachineTicker(IStateMachine machine, bool transfer)
        {
            Machine  = machine;
            Transfer = transfer;

            _Scene = SceneManager.GetActiveScene().buildIndex;
        }

        private bool _IsDisposed;
        private int  _Scene;

        public IStateMachine Machine  { get; }
        public bool          Transfer { get; }

        public bool IsValid
            => !_IsDisposed && Machine != null && _Scene == SceneManager.GetActiveScene().buildIndex;

        public void Tick()
        {
            if (Transfer) Machine.Transfer();

            Machine.LateTick();
        }

        public void Dispose()
        {
            _IsDisposed = true;
        }
    }
}
