using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    internal class PhaseStateMachine : ExpandStateMachine, IPhaseStateMachine
    {
        public PhaseStateMachine() : base()
        {
            
        }

        public PhaseStateMachine(IStateMachine core) : this(core, StateMachine.Identity.PhaseStatemachine)
        {
            
        }

        public PhaseStateMachine(IStateMachine core, object id) : base(core, id)
        {
            
        }

        #region IPhaseStateMachine

        public Func<bool> EnterEvent { get; set; } = FalseCondition;
        public Func<bool> ExitEvent  { get; set; }

        public Action OnEnterEvent { get; set; } = Callback;
        public Action OnExitEvent  { get; set; } = Callback;

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke() ?? false;
        public bool Exit  => ExitEvent?.Invoke() ?? Current.Exit;
        
        public void OnEnter()
        {
            Reset();

            OnEnterEvent?.Invoke();

            Watcher?.StartWatch();
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke();

            Watcher?.StopWatch();
        }

        #endregion

        #region IMachineNode

        public override void Dispose(bool disposeChild)
        {
            base.Dispose(disposeChild);

            EnterEvent = FalseCondition;
            ExitEvent  = default;

            OnEnterEvent = Callback;
            OnExitEvent  = Callback;

            SetIdentity(StateMachine.Identity.PhaseStatemachine);
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        #endregion

        private static bool FalseCondition() => false;
        private static bool TrueCondition()  => true;
        private static void Callback() { }
    }

    internal class PhaseStateMachine<T> : ExpandStateMachine, IPhaseStateMachine<T>
    {
        public PhaseStateMachine(T param1) : base()
        {
            _Param1 = param1;
        }

        public PhaseStateMachine(IStateMachine core, T param1) : this(core, param1, StateMachine.Identity.PhaseStatemachine)
        {
            
        }

        public PhaseStateMachine(IStateMachine core, T param1, object id) : base(core, id)
        {
            _Param1 = param1;
        }

        #region IPhaseStateMachine

        private T _Param1;

        public T Param1 => _Param1;

        public Func<T, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<T, bool> ExitEvent  { get; set; }

        public Action<T> OnEnterEvent { get; set; } = Callback;
        public Action<T> OnExitEvent  { get; set; } = Callback;

        public void SetParameters(T param1) 
        {
            _Param1 = param1;
        }

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1) ?? false;
        public bool Exit  => ExitEvent?.Invoke(Param1) ?? Current.Exit;

        
        public void OnEnter()
        {
            Reset();

            OnEnterEvent?.Invoke(Param1);

            Watcher?.StartWatch();
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1);

            Watcher?.StopWatch();
        }

        #endregion

        #region IMachineNode

        public override void Dispose(bool disposeChild)
        {
            base.Dispose(disposeChild);

            EnterEvent = FalseCondition;
            ExitEvent  = default;

            OnEnterEvent = Callback;
            OnExitEvent  = Callback;

            _Param1 = default;

            SetIdentity(StateMachine.Identity.PhaseStatemachine);
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        #endregion

        private static bool FalseCondition(T param1) => false;
        private static bool TrueCondition(T param1) => true;
        private static void Callback(T param1) { }
    }

    internal class PhaseStateMachine<T1, T2> : ExpandStateMachine, IPhaseStateMachine<T1, T2>
    {
        public PhaseStateMachine(T1 param1, T2 param2) : base()
        {
            _Param1 = param1;
            _Param2 = param2;
        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2) : this(core, param1, param2, StateMachine.Identity.PhaseStatemachine)
        {

        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, object id) : base(core, id)
        {
            _Param1 = param1;
            _Param2 = param2;
        }

        #region IPhaseStateMachine

        private T1 _Param1;
        private T2 _Param2;

        public T1 Param1 => _Param1;
        public T2 Param2 => _Param2;

        public Func<T1, T2, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<T1, T2, bool> ExitEvent  { get; set; }

        public Action<T1, T2> OnEnterEvent { get; set; } = Callback;
        public Action<T1, T2> OnExitEvent  { get; set; } = Callback;

        public void SetParameters(T1 param1, T2 param2)
        {
            _Param1 = param1;
            _Param2 = param2;
        }

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1, Param2) ?? false;
        public bool Exit  => ExitEvent?.Invoke(Param1, Param2) ?? Current.Exit;

        public void OnEnter()
        {
            Reset();

            OnEnterEvent?.Invoke(Param1, Param2);

            Watcher?.StartWatch();
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1, Param2);

            Watcher?.StopWatch();
        }

        #endregion

        #region IMachineNode

        public override void Dispose(bool disposeChild)
        {
            base.Dispose(disposeChild);

            EnterEvent = FalseCondition;
            ExitEvent = default;

            OnEnterEvent = Callback;
            OnExitEvent  = Callback;

            _Param1 = default;
            _Param2 = default;

            SetIdentity(StateMachine.Identity.PhaseStatemachine);
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        #endregion

        private static bool FalseCondition(T1 param1, T2 param2) => false;
        private static bool TrueCondition(T1 param1, T2 param2) => true;
        private static void Callback(T1 param1, T2 param2) { }
    }

    internal class PhaseStateMachine<T1, T2, T3> : ExpandStateMachine, IPhaseStateMachine<T1, T2, T3>
    {
        public PhaseStateMachine(T1 param1, T2 param2, T3 param3) : base()
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, T3 param3) : this(core, param1, param2, param3, StateMachine.Identity.PhaseStatemachine)
        {

        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, T3 param3, object id) : base(core, id)
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
        }

        #region IPhaseStateMachine

        private T1 _Param1;
        private T2 _Param2;
        private T3 _Param3;

        public T1 Param1 => _Param1;
        public T2 Param2 => _Param2;
        public T3 Param3 => _Param3;

        public Func<T1, T2, T3, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<T1, T2, T3, bool> ExitEvent  { get; set; }

        public Action<T1, T2, T3> OnEnterEvent { get; set; } = Callback;
        public Action<T1, T2, T3> OnExitEvent  { get; set; } = Callback;

        public void SetParameters(T1 param1, T2 param2, T3 param3)
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
        }

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1, Param2, Param3) ?? false;
        public bool Exit => ExitEvent?.Invoke(Param1, Param2, Param3) ?? Current.Exit;

        public void OnEnter()
        {
            Reset();

            OnEnterEvent?.Invoke(Param1, Param2, Param3);

            Watcher?.StartWatch();
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1, Param2, Param3);

            Watcher?.StopWatch();
        }

        #endregion

        #region IMachineNode

        public override void Dispose(bool disposeChild)
        {
            base.Dispose(disposeChild);

            EnterEvent = FalseCondition;
            ExitEvent  = default;

            OnEnterEvent = Callback;
            OnExitEvent  = Callback;

            _Param1 = default;
            _Param2 = default;
            _Param3 = default;

            SetIdentity(StateMachine.Identity.PhaseStatemachine);
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        #endregion

        private static bool FalseCondition(T1 param1, T2 param2, T3 param3) => false;
        private static bool TrueCondition(T1 param1, T2 param2, T3 param3) => true;
        private static void Callback(T1 param1, T2 param2, T3 param3) { }
    }

    internal class PhaseStateMachine<T1, T2, T3, T4> : ExpandStateMachine, IPhaseStateMachine<T1, T2, T3, T4>
    {
        public PhaseStateMachine(T1 param1, T2 param2, T3 param3, T4 param4) : base()
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
            _Param4 = param4;
        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, T3 param3, T4 param4) : this(core, param1, param2, param3, param4, StateMachine.Identity.PhaseStatemachine)
        {

        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, T3 param3, T4 param4, object id) : base(core, id)
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
            _Param4 = param4;
        }

        #region IPhaseStateMachine

        private T1 _Param1;
        private T2 _Param2;
        private T3 _Param3;
        private T4 _Param4;

        public T1 Param1 => _Param1;
        public T2 Param2 => _Param2;
        public T3 Param3 => _Param3;
        public T4 Param4 => _Param4;

        public Func<T1, T2, T3, T4, bool> EnterEvent { get; set; } = FalseCondition;
        public Func<T1, T2, T3, T4, bool> ExitEvent { get; set; }

        public Action<T1, T2, T3, T4> OnEnterEvent { get; set; } = Callback;
        public Action<T1, T2, T3, T4> OnExitEvent { get; set; } = Callback;

        public void SetParameters(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            _Param1 = param1;
            _Param2 = param2;
            _Param3 = param3;
            _Param4 = param4;
        }

        #endregion

        #region IState

        public bool Enter => EnterEvent?.Invoke(Param1, Param2, Param3, Param4) ?? false;
        public bool Exit => ExitEvent?.Invoke(Param1, Param2, Param3, Param4) ?? Current.Exit;

        public void OnEnter()
        {
            Reset();

            OnEnterEvent?.Invoke(Param1, Param2, Param3, Param4);

            Watcher?.StartWatch();
        }

        public void OnExit()
        {
            OnExitEvent?.Invoke(Param1, Param2, Param3, Param4);

            Watcher?.StopWatch();
        }

        #endregion

        #region IMachineNode

        public override void Dispose(bool disposeChild)
        {
            base.Dispose(disposeChild);

            EnterEvent = FalseCondition;
            ExitEvent  = default;

            OnEnterEvent = Callback;
            OnExitEvent  = Callback;

            _Param1 = default;
            _Param2 = default;
            _Param3 = default;
            _Param4 = default;

            SetIdentity(StateMachine.Identity.PhaseStatemachine);
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        #endregion

        private static bool FalseCondition(T1 param1, T2 param2, T3 param3, T4 param4) => false;
        private static bool TrueCondition(T1 param1, T2 param2, T3 param3, T4 param4) => true;
        private static void Callback(T1 param1, T2 param2, T3 param3, T4 param4) { }
    }
}
