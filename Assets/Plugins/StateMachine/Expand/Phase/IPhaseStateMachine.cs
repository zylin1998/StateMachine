using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IPhaseStateMachine : IStateMachine, IState
    {
        public Func<bool> EnterEvent { get; set; }
        public Func<bool> ExitEvent  { get; set; }

        public Action OnEnterEvent { get; set; }
        public Action OnExitEvent  { get; set; }
    }

    public interface IPhaseStateMachine<TParam1> : IStateMachine, IState
    {
        public Func<TParam1, bool> EnterEvent { get; set; }
        public Func<TParam1, bool> ExitEvent  { get; set; }

        public Action<TParam1> OnEnterEvent { get; set; }
        public Action<TParam1> OnExitEvent  { get; set; }
    }

    public interface IPhaseStateMachine<TParam1, TParam2> : IStateMachine, IState
    {
        public Func<TParam1, TParam2, bool> EnterEvent { get; set; }
        public Func<TParam1, TParam2, bool> ExitEvent  { get; set; }

        public Action<TParam1, TParam2> OnEnterEvent { get; set; }
        public Action<TParam1, TParam2> OnExitEvent  { get; set; }
    }

    public interface IPhaseStateMachine<TParam1, TParam2, TParam3> : IStateMachine, IState
    {
        public Func<TParam1, TParam2, TParam3, bool> EnterEvent { get; set; }
        public Func<TParam1, TParam2, TParam3, bool> ExitEvent  { get; set; }

        public Action<TParam1, TParam2, TParam3> OnEnterEvent { get; set; }
        public Action<TParam1, TParam2, TParam3> OnExitEvent  { get; set; }
    }

    public interface IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> : IStateMachine, IState
    {
        public Func<TParam1, TParam2, TParam3, TParam4, bool> EnterEvent { get; set; }
        public Func<TParam1, TParam2, TParam3, TParam4, bool> ExitEvent { get; set; }

        public Action<TParam1, TParam2, TParam3, TParam4> OnEnterEvent { get; set; }
        public Action<TParam1, TParam2, TParam3, TParam4> OnExitEvent { get; set; }
    }
}
