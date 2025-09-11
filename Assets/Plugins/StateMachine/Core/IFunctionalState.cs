using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IFunctionalState : IState
    {
        public Func<bool> EnterEvent { get; set; }
        public Func<bool> ExitEvent  { get; set; }

        public Action OnEnterEvent   { get; set; }
        public Action OnExitEvent    { get; set; }
        public Action TickEvent      { get; set; }
        public Action FixedTickEvent { get; set; }
        public Action LateTickEvent  { get; set; }
    }

    public interface IFunctionalState<TParam1> : IState
    {
        public Func<TParam1, bool> EnterEvent     { get; set; }
        public Func<TParam1, bool> ExitEvent      { get; set; }

        public Action<TParam1> OnEnterEvent   { get; set; }
        public Action<TParam1> OnExitEvent    { get; set; }
        public Action<TParam1> TickEvent      { get; set; }
        public Action<TParam1> FixedTickEvent { get; set; }
        public Action<TParam1> LateTickEvent  { get; set; }
    }

    public interface IFunctionalState<TParam1, TParam2> : IState
    {
        public Func<TParam1, TParam2, bool> EnterEvent { get; set; }
        public Func<TParam1, TParam2, bool> ExitEvent { get; set; }

        public Action<TParam1, TParam2> OnEnterEvent   { get; set; }
        public Action<TParam1, TParam2> OnExitEvent    { get; set; }
        public Action<TParam1, TParam2> TickEvent      { get; set; }
        public Action<TParam1, TParam2> FixedTickEvent { get; set; }
        public Action<TParam1, TParam2> LateTickEvent  { get; set; }
    }

    public interface IFunctionalState<TParam1, TParam2, TParam3> : IState
    {
        public Func<TParam1, TParam2, TParam3, bool> EnterEvent { get; set; }
        public Func<TParam1, TParam2, TParam3, bool> ExitEvent { get; set; }

        public Action<TParam1, TParam2, TParam3> OnEnterEvent   { get; set; }
        public Action<TParam1, TParam2, TParam3> OnExitEvent    { get; set; }
        public Action<TParam1, TParam2, TParam3> TickEvent      { get; set; }
        public Action<TParam1, TParam2, TParam3> FixedTickEvent { get; set; }
        public Action<TParam1, TParam2, TParam3> LateTickEvent  { get; set; }
    }

    public interface IFunctionalState<TParam1, TParam2, TParam3, TParam4> : IState
    {
        public Func<TParam1, TParam2, TParam3, TParam4, bool> EnterEvent { get; set; }
        public Func<TParam1, TParam2, TParam3, TParam4, bool> ExitEvent { get; set; }

        public Action<TParam1, TParam2, TParam3, TParam4> OnEnterEvent   { get; set; }
        public Action<TParam1, TParam2, TParam3, TParam4> OnExitEvent    { get; set; }
        public Action<TParam1, TParam2, TParam3, TParam4> TickEvent      { get; set; }
        public Action<TParam1, TParam2, TParam3, TParam4> FixedTickEvent { get; set; }
        public Action<TParam1, TParam2, TParam3, TParam4> LateTickEvent  { get; set; }
    }
}
