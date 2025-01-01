using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    public interface IPhaseStateMachine : IStateMachine, IState
    {
        /// <summary>
        /// 階層狀態機進入點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine EnterWhen(Func<bool> condition);
        /// <summary>
        /// 階層狀態機離開點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine ExitWhen (Func<bool> condition);

        /// <summary>
        /// 階層狀態機進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine DoOnEnter(Action callback);
        /// <summary>
        /// 階層狀態機離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine DoOnExit (Action callback);

        /// <summary>
        /// 階層狀態機 Identity 設置。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPhaseStateMachine WithId(object id);
    }

    public interface IPhaseStateMachine<TParam1> : IStateMachine, IState
    {
        /// <summary>
        /// 階層狀態機進入點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1> EnterWhen(Func<TParam1, bool> condition);
        /// <summary>
        /// 階層狀態機離開點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1> ExitWhen(Func<TParam1, bool> condition);

        /// <summary>
        /// 階層狀態機進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1> DoOnEnter(Action<TParam1> callback);
        /// <summary>
        /// 階層狀態機離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1> DoOnExit(Action<TParam1> callback);

        /// <summary>
        /// 階層狀態機 Identity 設置。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1> WithId(object id);
    }

    public interface IPhaseStateMachine<TParam1, TParam2> : IStateMachine, IState
    {
        /// <summary>
        /// 階層狀態機進入點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2> EnterWhen(Func<TParam1, TParam2, bool> condition);
        /// <summary>
        /// 階層狀態機離開點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2> ExitWhen(Func<TParam1, TParam2, bool> condition);

        /// <summary>
        /// 階層狀態機進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2> DoOnEnter(Action<TParam1, TParam2> callback);
        /// <summary>
        /// 階層狀態機離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2> DoOnExit(Action<TParam1, TParam2> callback);

        /// <summary>
        /// 階層狀態機 Identity 設置。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2> WithId(object id);
    }

    public interface IPhaseStateMachine<TParam1, TParam2, TParam3> : IStateMachine, IState
    {
        /// <summary>
        /// 階層狀態機進入點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3> EnterWhen(Func<TParam1, TParam2, TParam3, bool> condition);
        /// <summary>
        /// 階層狀態機離開點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3> ExitWhen(Func<TParam1, TParam2, TParam3, bool> condition);

        /// <summary>
        /// 階層狀態機進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3> DoOnEnter(Action<TParam1, TParam2, TParam3> callback);
        /// <summary>
        /// 階層狀態機離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3> DoOnExit(Action<TParam1, TParam2, TParam3> callback);

        /// <summary>
        /// 階層狀態機 Identity 設置。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3> WithId(object id);
    }

    public interface IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> : IStateMachine, IState
    {
        /// <summary>
        /// 階層狀態機進入點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> EnterWhen(Func<TParam1, TParam2, TParam3, TParam4, bool> condition);
        /// <summary>
        /// 階層狀態機離開點設置。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> ExitWhen(Func<TParam1, TParam2, TParam3, TParam4, bool> condition);

        /// <summary>
        /// 階層狀態機進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> DoOnEnter(Action<TParam1, TParam2, TParam3, TParam4> callback);
        /// <summary>
        /// 階層狀態機離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> DoOnExit(Action<TParam1, TParam2, TParam3, TParam4> callback);

        /// <summary>
        /// 階層狀態機 Identity 設置。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPhaseStateMachine<TParam1, TParam2, TParam3, TParam4> WithId(object id);
    }
}
