using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace StateMachineX
{
    internal class FunctionalState : IFunctionalState
    {
        public Func<bool> EnterEvent { get; set; } = FalseCondition;
        public Func<bool> ExitEvent  { get; set; } = TrueCondition;

        public Action OnEnterEvent   { get; set; } = Callback;
        public Action OnExitEvent    { get; set; } = Callback;
        public Action TickEvent      { get; set; } = Callback;
        public Action FixedTickEvent { get; set; } = Callback;
        public Action LateTickEvent  { get; set; } = Callback;

        #region IState

        public bool Enter => EnterEvent?.Invoke() ?? false;
        public bool Exit  => ExitEvent?.Invoke() ?? true;


        public void OnEnter()
        {
            OnEnterEvent?.Invoke();
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke();
        }

        public void Tick()
        {
            TickEvent?.Invoke();
        }

        public void FixedTick()
        {
            FixedTickEvent?.Invoke();
        }

        public void LateTick()
        {
            LateTickEvent?.Invoke();
        }

        #endregion

        #region StateMachineNode

        private object _Identity;

        public object Identity 
        {
            get => _Identity; 
            
            private set => _Identity = value; 
        }

        public bool HasChild => false;

        public void SetIdentity(object identity)
        {
            Identity = identity;
        }

        public void Reset() 
        {

        }

        public void Dispose()
        {
            EnterEvent = FalseCondition;
            ExitEvent  = TrueCondition;

            OnEnterEvent   = Callback;
            OnExitEvent    = Callback;
            TickEvent      = Callback;
            FixedTickEvent = Callback;
            LateTickEvent  = Callback;
        }

        #endregion

        private static void Callback() { }
        private static bool TrueCondition()  => true;
        private static bool FalseCondition() => false;
    }

    internal class FunctionalState<TParam1> : IFunctionalState<TParam1>
    {
        public FunctionalState(TParam1 param1)
        {
            _Param1 = param1;
        }

        private TParam1 _Param1;

        public TParam1 Param1 => _Param1;

        #region IFunctionalState

        public Func<TParam1, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<TParam1, bool> ExitEvent  { get; set; } = TrueCondition;

        public Action<TParam1> OnEnterEvent   { get; set; } = Callback;
        public Action<TParam1> OnExitEvent    { get; set; } = Callback;
        public Action<TParam1> TickEvent      { get; set; } = Callback;
        public Action<TParam1> FixedTickEvent { get; set; } = Callback;
        public Action<TParam1> LateTickEvent  { get; set; } = Callback;

        #endregion

        #region IState


        public bool Enter => EnterEvent?.Invoke(Param1) ?? false;
        public bool Exit  => ExitEvent?.Invoke(Param1)  ?? true;

        public void OnEnter()
        {
            OnEnterEvent?.Invoke(Param1);
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1);
        }

        public void Tick()
        {
            TickEvent?.Invoke(Param1);
        }

        public void FixedTick()
        {
            FixedTickEvent?.Invoke(Param1);
        }

        public void LateTick()
        {
            LateTickEvent?.Invoke(Param1);
        }

        #endregion

        #region IStateMachineNode

        public object Identity { get; private set; }

        public bool HasChild => false;

        public void SetIdentity(object identity)
        {
            Identity = identity;
        }

        public void Reset()
        {

        }

        public void Dispose()
        {
            EnterEvent = FalseCondition;
            ExitEvent = TrueCondition;

            OnEnterEvent   = Callback;
            OnExitEvent    = Callback;
            TickEvent      = Callback;
            FixedTickEvent = Callback;
            LateTickEvent  = Callback;
        }

        #endregion

        private static void Callback(TParam1 param1) { }
        private static bool TrueCondition(TParam1 param1) => true;
        private static bool FalseCondition(TParam1 param1) => false;
    }

    internal class FunctionalState<TParam1, TParam2> : IFunctionalState<TParam1, TParam2>
    {
        public FunctionalState(TParam1 param1, TParam2 param2)
        {
            _Param1 = param1;
            _Param2 = param2;
        }

        private TParam1 _Param1;
        private TParam2 _Param2;

        public TParam1 Param1 => _Param1;
        public TParam2 Param2 => _Param2;

        #region IFunctionalState

        public Func<TParam1, TParam2, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<TParam1, TParam2, bool> ExitEvent  { get; set; } = TrueCondition;

        public Action<TParam1, TParam2> OnEnterEvent   { get; set; } = Callback;
        public Action<TParam1, TParam2> OnExitEvent    { get; set; } = Callback;
        public Action<TParam1, TParam2> TickEvent      { get; set; } = Callback;
        public Action<TParam1, TParam2> FixedTickEvent { get; set; } = Callback;
        public Action<TParam1, TParam2> LateTickEvent  { get; set; } = Callback;

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1, Param2) ?? false;
        public bool Exit => ExitEvent?.Invoke(Param1, Param2) ?? true;

        public void OnEnter()
        {
            OnEnterEvent?.Invoke(Param1, Param2);
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1, Param2);
        }

        public void Tick()
        {
            TickEvent?.Invoke(Param1, Param2);
        }

        public void FixedTick()
        {
            FixedTickEvent?.Invoke(Param1, Param2);
        }

        public void LateTick()
        {
            LateTickEvent?.Invoke(Param1, Param2);
        }

        #endregion

        #region IStateMachineNode

        private object _Identity;

        public object Identity 
        { 
            get => _Identity; 
            
            private set => _Identity = value; 
        }

        public bool HasChild => false;

        public void SetIdentity(object identity)
        {
            Identity = identity;
        }

        public void Reset()
        {

        }

        public void Dispose()
        {
            EnterEvent = FalseCondition;
            ExitEvent  = TrueCondition;

            OnEnterEvent   = Callback;
            OnExitEvent    = Callback;
            TickEvent      = Callback;
            FixedTickEvent = Callback;
            LateTickEvent  = Callback;
        }

        #endregion

        private static void Callback(TParam1 param1, TParam2 param2) { }
        private static bool TrueCondition (TParam1 param1, TParam2 param2) => true;
        private static bool FalseCondition(TParam1 param1, TParam2 param2) => false;
    }

    internal class FunctionalState<TParam1, TParam2, TParam3> : IFunctionalState<TParam1, TParam2, TParam3>
    {
        public FunctionalState(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
        }

        private TParam1 _Param1;
        private TParam2 _Param2;
        private TParam3 _Param3;

        public TParam1 Param1 => _Param1;
        public TParam2 Param2 => _Param2;
        public TParam3 Param3 => _Param3;

        #region IFunctionalState

        public Func<TParam1, TParam2, TParam3, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<TParam1, TParam2, TParam3, bool> ExitEvent  { get; set; } = TrueCondition;

        public Action<TParam1, TParam2, TParam3> OnEnterEvent   { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3> OnExitEvent    { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3> TickEvent      { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3> FixedTickEvent { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3> LateTickEvent  { get; set; } = Callback;

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1, Param2, Param3) ?? false;
        public bool Exit  => ExitEvent?.Invoke(Param1, Param2, Param3) ?? true;

        public void OnEnter()
        {
            OnEnterEvent?.Invoke(Param1, Param2, Param3);
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1, Param2, Param3);
        }

        public void Tick()
        {
            TickEvent?.Invoke(Param1, Param2, Param3);
        }

        public void FixedTick()
        {
            FixedTickEvent?.Invoke(Param1, Param2, Param3);
        }

        public void LateTick()
        {
            LateTickEvent?.Invoke(Param1, Param2, Param3);
        }

        #endregion

        #region IStateMachineNode

        private object _Identity;

        public object Identity
        {
            get => _Identity;

            private set => _Identity = value;
        }

        public bool HasChild => false;

        public void SetIdentity(object identity)
        {
            Identity = identity;
        }

        public void Reset()
        {

        }

        public void Dispose()
        {
            EnterEvent = FalseCondition;
            ExitEvent  = TrueCondition;

            OnEnterEvent   = Callback;
            OnExitEvent    = Callback;
            TickEvent      = Callback;
            FixedTickEvent = Callback;
            LateTickEvent  = Callback;
        }

        #endregion

        private static void Callback(TParam1 param1, TParam2 param2, TParam3 param3) { }
        private static bool TrueCondition(TParam1 param1, TParam2 param2, TParam3 param3) => true;
        private static bool FalseCondition(TParam1 param1, TParam2 param2, TParam3 param3) => false;
    }

    internal class FunctionalState<TParam1, TParam2, TParam3, TParam4> : IFunctionalState<TParam1, TParam2, TParam3, TParam4>
    {
        public FunctionalState(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
            _Param4 = param4;
        }

        private TParam1 _Param1;
        private TParam2 _Param2;
        private TParam3 _Param3;
        private TParam4 _Param4;

        public TParam1 Param1 => _Param1;
        public TParam2 Param2 => _Param2;
        public TParam3 Param3 => _Param3;
        public TParam4 Param4 => _Param4;


        #region IFunctionalState

        public Func<TParam1, TParam2, TParam3, TParam4, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<TParam1, TParam2, TParam3, TParam4, bool> ExitEvent  { get; set; } = TrueCondition;

        public Action<TParam1, TParam2, TParam3, TParam4> OnEnterEvent   { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3, TParam4> OnExitEvent    { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3, TParam4> TickEvent      { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3, TParam4> FixedTickEvent { get; set; } = Callback;
        public Action<TParam1, TParam2, TParam3, TParam4> LateTickEvent  { get; set; } = Callback;

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1, Param2, Param3, Param4) ?? false;
        public bool Exit  => ExitEvent?.Invoke(Param1, Param2, Param3, Param4) ?? true;

        public void OnEnter()
        {
            OnEnterEvent?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void Tick()
        {
            TickEvent?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void FixedTick()
        {
            FixedTickEvent?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void LateTick()
        {
            LateTickEvent?.Invoke(Param1, Param2, Param3, Param4);
        }

        #endregion

        #region IStateMachineNode

        private object _Identity;

        public object Identity
        {
            get => _Identity;

            private set => _Identity = value;
        }

        public bool HasChild => false;

        public void SetIdentity(object identity)
        {
            Identity = identity;
        }

        public void Reset()
        {

        }

        public void Dispose()
        {
            EnterEvent = FalseCondition;
            ExitEvent  = TrueCondition;

            OnEnterEvent   = Callback;
            OnExitEvent    = Callback;
            TickEvent      = Callback;
            FixedTickEvent = Callback;
            LateTickEvent  = Callback;
        }

        #endregion

        private static void Callback(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) { }
        private static bool TrueCondition(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) => true;
        private static bool FalseCondition(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) => false;
    }
}
