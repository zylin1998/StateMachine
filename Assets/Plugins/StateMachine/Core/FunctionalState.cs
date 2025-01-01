using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    internal class FunctionalState : IFunctionalState
    {
        public FunctionalState()
            => (_Enter, _Exit, _OnEnter, _OnExit, _Tick, _FixedTick, _LateTick)
                    = (FalseCondition, TrueCondition, Callback, Callback, Callback, Callback, Callback);
        

        private Func<bool> _Enter, _Exit;

        private Action _OnEnter, _OnExit;

        private Action _Tick, _FixedTick, _LateTick;

        #region IFunctionalState

        public IFunctionalState EnterWhen(Func<bool> condition) 
        {
            _Enter = condition;

            return this;
        }

        public IFunctionalState ExitWhen(Func<bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IFunctionalState DoOnEnter(Action callback) 
        {
            _OnEnter = callback;

            return this;
        }

        public IFunctionalState DoOnExit(Action callback)
        {
            _OnExit = callback;

            return this;
        }

        public IFunctionalState DoTick(Action callback)
        {
            _Tick = callback;

            return this;
        }

        public IFunctionalState DoFixedTick(Action callback)
        {
            _FixedTick = callback;

            return this;
        }

        public IFunctionalState DoLateTick(Action callback)
        {
            _LateTick = callback;

            return this;
        }

        public IFunctionalState WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter != null ? _Enter.Invoke() : false;
        public bool Exit  => _Exit  != null ? _Exit .Invoke() : true;

        public void OnEnter() 
        {
            _OnEnter?.Invoke();
        }

        public void OnExit()
        {
            _OnExit?.Invoke();
        }

        public void Tick() 
        {
            _Tick?.Invoke();
        }

        public void FixedTick()
        {
            _FixedTick?.Invoke();
        }

        public void LateTick()
        {
            _LateTick?.Invoke();
        }

        #endregion

        private static void Callback      () { }
        private static bool TrueCondition () => true;
        private static bool FalseCondition() => false;
    }

    internal class FunctionalState<TParam1> : IFunctionalState<TParam1>
    {
        public FunctionalState(TParam1 param1)
        {
            (_Enter, _Exit) = (FalseCondition, TrueCondition);
            (_OnEnter, _OnExit) = (Callback, Callback);
            (_Tick, _FixedTick, _LateTick) = (Callback, Callback, Callback);

            Param1 = param1;
        }


        private Func<TParam1, bool> _Enter, _Exit;

        private Action<TParam1> _OnEnter, _OnExit;

        private Action<TParam1> _Tick, _FixedTick, _LateTick;

        public TParam1 Param1 { get; }

        #region IFunctionalState

        public IFunctionalState<TParam1> EnterWhen(Func<TParam1, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IFunctionalState<TParam1> ExitWhen(Func<TParam1, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IFunctionalState<TParam1> DoOnEnter(Action<TParam1> callback)
        {
            _OnEnter = callback;

            return this;
        }

        public IFunctionalState<TParam1> DoOnExit(Action<TParam1> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IFunctionalState<TParam1> DoTick(Action<TParam1> callback)
        {
            _Tick = callback;

            return this;
        }

        public IFunctionalState<TParam1> DoFixedTick(Action<TParam1> callback)
        {
            _FixedTick = callback;

            return this;
        }

        public IFunctionalState<TParam1> DoLateTick(Action<TParam1> callback)
        {
            _LateTick = callback;

            return this;
        }

        public IFunctionalState<TParam1> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter != null ? _Enter.Invoke(Param1) : false;
        public bool Exit  => _Exit  != null ? _Exit .Invoke(Param1) : true;

        public void OnEnter()
        {
            _OnEnter?.Invoke(Param1);
        }

        public void OnExit()
        {
            _OnExit?.Invoke(Param1);
        }

        public void Tick()
        {
            _Tick?.Invoke(Param1);
        }

        public void FixedTick()
        {
            _FixedTick?.Invoke(Param1);
        }

        public void LateTick()
        {
            _LateTick?.Invoke(Param1);
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
            (_Enter, _Exit) = (FalseCondition, TrueCondition);
            (_OnEnter, _OnExit) = (Callback, Callback);
            (_Tick, _FixedTick, _LateTick) = (Callback, Callback, Callback);

            Param1 = param1;
            Param2 = param2;
        }


        private Func<TParam1, TParam2, bool> _Enter, _Exit;

        private Action<TParam1, TParam2> _OnEnter, _OnExit;

        private Action<TParam1, TParam2> _Tick, _FixedTick, _LateTick;

        public TParam1 Param1 { get; }
        public TParam2 Param2 { get; }

        #region IFunctionalState

        public IFunctionalState<TParam1, TParam2> EnterWhen(Func<TParam1, TParam2, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> ExitWhen(Func<TParam1, TParam2, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> DoOnEnter(Action<TParam1, TParam2> callback)
        {
            _OnEnter = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> DoOnExit(Action<TParam1, TParam2> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> DoTick(Action<TParam1, TParam2> callback)
        {
            _Tick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> DoFixedTick(Action<TParam1, TParam2> callback)
        {
            _FixedTick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> DoLateTick(Action<TParam1, TParam2> callback)
        {
            _LateTick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter != null ? _Enter.Invoke(Param1, Param2) : false;
        public bool Exit  => _Exit  != null ? _Exit .Invoke(Param1, Param2) : true;

        public void OnEnter()
        {
            _OnEnter?.Invoke(Param1, Param2);
        }

        public void OnExit()
        {
            _OnExit?.Invoke(Param1, Param2);
        }

        public void Tick()
        {
            _Tick?.Invoke(Param1, Param2);
        }

        public void FixedTick()
        {
            _FixedTick?.Invoke(Param1, Param2);
        }

        public void LateTick()
        {
            _LateTick?.Invoke(Param1, Param2);
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
            (_Enter, _Exit) = (FalseCondition, TrueCondition);
            (_OnEnter, _OnExit) = (Callback, Callback);
            (_Tick, _FixedTick, _LateTick) = (Callback, Callback, Callback);

            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }


        private Func<TParam1, TParam2, TParam3, bool> _Enter, _Exit;

        private Action<TParam1, TParam2, TParam3> _OnEnter, _OnExit;

        private Action<TParam1, TParam2, TParam3> _Tick, _FixedTick, _LateTick;

        public TParam1 Param1 { get; }
        public TParam2 Param2 { get; }
        public TParam3 Param3 { get; }

        #region IFunctionalState

        public IFunctionalState<TParam1, TParam2, TParam3> EnterWhen(Func<TParam1, TParam2, TParam3, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> ExitWhen(Func<TParam1, TParam2, TParam3, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> DoOnEnter(Action<TParam1, TParam2, TParam3> callback)
        {
            _OnEnter = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> DoOnExit(Action<TParam1, TParam2, TParam3> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> DoTick(Action<TParam1, TParam2, TParam3> callback)
        {
            _Tick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> DoFixedTick(Action<TParam1, TParam2, TParam3> callback)
        {
            _FixedTick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> DoLateTick(Action<TParam1, TParam2, TParam3> callback)
        {
            _LateTick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter != null ? _Enter.Invoke(Param1, Param2, Param3) : false;
        public bool Exit  => _Exit != null  ? _Exit .Invoke(Param1, Param2, Param3) : true;

        public void OnEnter()
        {
            _OnEnter?.Invoke(Param1, Param2, Param3);
        }

        public void OnExit()
        {
            _OnExit?.Invoke(Param1, Param2, Param3);
        }

        public void Tick()
        {
            _Tick?.Invoke(Param1, Param2, Param3);
        }

        public void FixedTick()
        {
            _FixedTick?.Invoke(Param1, Param2, Param3);
        }

        public void LateTick()
        {
            _LateTick?.Invoke(Param1, Param2, Param3);
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
            (_Enter, _Exit) = (FalseCondition, TrueCondition);
            (_OnEnter, _OnExit) = (Callback, Callback);
            (_Tick, _FixedTick, _LateTick) = (Callback, Callback, Callback);

            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;
        }


        private Func<TParam1, TParam2, TParam3, TParam4, bool> _Enter, _Exit;

        private Action<TParam1, TParam2, TParam3, TParam4> _OnEnter, _OnExit;

        private Action<TParam1, TParam2, TParam3, TParam4> _Tick, _FixedTick, _LateTick;

        public TParam1 Param1 { get; }
        public TParam2 Param2 { get; }
        public TParam3 Param3 { get; }
        public TParam4 Param4 { get; }

        #region IFunctionalState

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> EnterWhen(Func<TParam1, TParam2, TParam3, TParam4, bool> condition)
        {
            _Enter = condition;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> ExitWhen(Func<TParam1, TParam2, TParam3, TParam4, bool> condition)
        {
            _Exit = condition;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoOnEnter(Action<TParam1, TParam2, TParam3, TParam4> callback)
        {
            _OnEnter = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoOnExit(Action<TParam1, TParam2, TParam3, TParam4> callback)
        {
            _OnExit = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoTick(Action<TParam1, TParam2, TParam3, TParam4> callback)
        {
            _Tick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoFixedTick(Action<TParam1, TParam2, TParam3, TParam4> callback)
        {
            _FixedTick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoLateTick(Action<TParam1, TParam2, TParam3, TParam4> callback)
        {
            _LateTick = callback;

            return this;
        }

        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> WithId(object identity)
        {
            Identity = identity;

            return this;
        }

        #endregion

        #region IState

        public object Identity { get; private set; }

        public bool Enter => _Enter != null ? _Enter.Invoke(Param1, Param2, Param3, Param4) : false;
        public bool Exit  =>  _Exit != null ? _Exit .Invoke(Param1, Param2, Param3, Param4) : true;

        public void OnEnter()
        {
            _OnEnter?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void OnExit()
        {
            _OnExit?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void Tick()
        {
            _Tick?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void FixedTick()
        {
            _FixedTick?.Invoke(Param1, Param2, Param3, Param4);
        }

        public void LateTick()
        {
            _LateTick?.Invoke(Param1, Param2, Param3, Param4);
        }

        #endregion

        private static void Callback(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) { }
        private static bool TrueCondition(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) => true;
        private static bool FalseCondition(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) => false;
    }
}
