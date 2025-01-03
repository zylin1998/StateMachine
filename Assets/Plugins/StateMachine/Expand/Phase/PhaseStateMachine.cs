using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    internal class PhaseStateMachine : ExpandStateMachine, IPhaseStateMachine
    {
        public PhaseStateMachine() : base()
        {
            (_Enter, _Exit) = (FalseCondition, () => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        public PhaseStateMachine(IStateMachine core) : base(core)
        {
            (_Enter, _Exit) = (FalseCondition, () => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        private Func<bool> _Enter, _Exit;

        private Action _OnEnter, _OnExit;

        #region IPhaseStateMachine

        public IPhaseStateMachine EnterWhen(Func<bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IPhaseStateMachine ExitWhen(Func<bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IPhaseStateMachine DoOnEnter(Action callback)
        {
            _OnEnter = callback;

            Dispose();

            return this;
        }

        public IPhaseStateMachine DoOnExit(Action callback)
        {
            _OnExit = callback;

            return this;
        }

        public IPhaseStateMachine WithId(object identity) 
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter.Invoke();
        public bool Exit  => _Exit.Invoke();

        public void OnEnter()
        {
            _OnEnter.Invoke();
        }

        public void OnExit()
        {
            _OnExit.Invoke();
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
            Param1 = param1;

            (_Enter, _Exit) = (FalseCondition, (p1) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        public PhaseStateMachine(IStateMachine core, T param1) : base(core)
        {
            Param1 = param1;

            (_Enter, _Exit) = (FalseCondition, (p1) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        private Func<T, bool> _Enter, _Exit;

        private Action<T> _OnEnter, _OnExit;

        public T Param1 { get; }

        #region IPhaseStateMachine

        public IPhaseStateMachine<T> EnterWhen(Func<T, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IPhaseStateMachine<T> ExitWhen(Func<T, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IPhaseStateMachine<T> DoOnEnter(Action<T> callback)
        {
            _OnEnter = callback;

            Dispose();

            return this;
        }

        public IPhaseStateMachine<T> DoOnExit(Action<T> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IPhaseStateMachine<T> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter.Invoke(Param1);
        public bool Exit  => _Exit.Invoke(Param1);

        public void OnEnter()
        {
            _OnEnter.Invoke(Param1);
        }

        public void OnExit()
        {
            _OnExit.Invoke(Param1);
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
            Param1 = param1;
            Param2 = param2;

            (_Enter, _Exit) = (FalseCondition, (p1, p2) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2) : base(core)
        {
            Param1 = param1;
            Param2 = param2;

            (_Enter, _Exit) = (FalseCondition, (p1, p2) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        private Func<T1, T2, bool> _Enter, _Exit;

        private Action<T1, T2> _OnEnter, _OnExit;

        public T1 Param1 { get; }
        public T2 Param2 { get; }

        #region IPhaseStateMachine

        public IPhaseStateMachine<T1, T2> EnterWhen(Func<T1, T2, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IPhaseStateMachine<T1, T2> ExitWhen(Func<T1, T2, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IPhaseStateMachine<T1, T2> DoOnEnter(Action<T1, T2> callback)
        {
            _OnEnter = callback;

            Dispose();

            return this;
        }

        public IPhaseStateMachine<T1, T2> DoOnExit(Action<T1, T2> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IPhaseStateMachine<T1, T2> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter.Invoke(Param1, Param2);
        public bool Exit  => _Exit .Invoke(Param1, Param2);

        public void OnEnter()
        {
            _OnEnter.Invoke(Param1, Param2);
        }

        public void OnExit()
        {
            _OnExit.Invoke(Param1, Param2);
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
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;

            (_Enter, _Exit) = (FalseCondition, (p1, p2, p3) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, T3 param3) : base(core)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;

            (_Enter, _Exit) = (FalseCondition, (p1, p2, p3) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        private Func<T1, T2, T3, bool> _Enter, _Exit;

        private Action<T1, T2, T3> _OnEnter, _OnExit;

        public T1 Param1 { get; }
        public T2 Param2 { get; }
        public T3 Param3 { get; }

        #region IPhaseStateMachine

        public IPhaseStateMachine<T1, T2, T3> EnterWhen(Func<T1, T2, T3, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3> ExitWhen(Func<T1, T2, T3, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3> DoOnEnter(Action<T1, T2, T3> callback)
        {
            _OnEnter = callback;

            Dispose();

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3> DoOnExit(Action<T1, T2, T3> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter.Invoke(Param1, Param2, Param3);
        public bool Exit  => _Exit .Invoke(Param1, Param2, Param3);

        public void OnEnter()
        {
            _OnEnter.Invoke(Param1, Param2, Param3);
        }

        public void OnExit()
        {
            _OnExit.Invoke(Param1, Param2, Param3);
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
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;

            (_Enter, _Exit) = (FalseCondition, (p1, p2, p3, p4) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        public PhaseStateMachine(IStateMachine core, T1 param1, T2 param2, T3 param3, T4 param4) : base(core)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;

            (_Enter, _Exit) = (FalseCondition, (p1, p2, p3, p4) => Current.Exit);

            (_OnEnter, _OnExit) = (Callback, Callback);
        }

        private Func<T1, T2, T3, T4, bool> _Enter, _Exit;

        private Action<T1, T2, T3, T4> _OnEnter, _OnExit;

        public T1 Param1 { get; }
        public T2 Param2 { get; }
        public T3 Param3 { get; }
        public T4 Param4 { get; }

        #region IPhaseStateMachine

        public IPhaseStateMachine<T1, T2, T3, T4> EnterWhen(Func<T1, T2, T3, T4, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3, T4> ExitWhen(Func<T1, T2, T3, T4, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3, T4> DoOnEnter(Action<T1, T2, T3, T4> callback)
        {
            _OnEnter = callback;

            Dispose();

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3, T4> DoOnExit(Action<T1, T2, T3, T4> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IPhaseStateMachine<T1, T2, T3, T4> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter.Invoke(Param1, Param2, Param3, Param4);
        public bool Exit  => _Exit .Invoke(Param1, Param2, Param3, Param4);

        public void OnEnter()
        {
            _OnEnter.Invoke(Param1, Param2, Param3, Param4);
        }

        public void OnExit()
        {
            _OnExit.Invoke(Param1, Param2, Param3, Param4);
        }

        #endregion

        private static bool FalseCondition(T1 param1, T2 param2, T3 param3, T4 param4) => false;
        private static bool TrueCondition(T1 param1, T2 param2, T3 param3, T4 param4) => true;
        private static void Callback(T1 param1, T2 param2, T3 param3, T4 param4) { }
    }
}
