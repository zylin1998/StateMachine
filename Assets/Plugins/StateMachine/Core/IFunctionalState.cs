using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IFunctionalState : IState
    {
        /// <summary>
        /// 自訂義狀態進入點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState EnterWhen(Func<bool> condition);
        /// <summary>
        /// 自訂義狀態離開點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState ExitWhen(Func<bool> condition);

        /// <summary>
        /// 自訂義狀態進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState DoOnEnter(Action callback);
        /// <summary>
        /// 自訂義狀態離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState DoOnExit(Action callback);

        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity Update)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState DoTick(Action callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity FixedUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState DoFixedTick(Action callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity LateUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState DoLateTick(Action callback);

        /// <summary>
        /// 自訂義狀態Identity設置。
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IFunctionalState WithId(object identity);
    }

    public interface IFunctionalState<TParam1> : IState
    {
        /// <summary>
        /// 自訂義狀態進入點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> EnterWhen(Func<TParam1, bool> condition);
        /// <summary>
        /// 自訂義狀態離開點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> ExitWhen(Func<TParam1, bool> condition);

        /// <summary>
        /// 自訂義狀態進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> DoOnEnter(Action<TParam1> callback);
        /// <summary>
        /// 自訂義狀態離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> DoOnExit(Action<TParam1> callback);

        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity Update)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> DoTick(Action<TParam1> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity FixedUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> DoFixedTick(Action<TParam1> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity LateUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> DoLateTick(Action<TParam1> callback);

        /// <summary>
        /// 自訂義狀態Identity設置。
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1> WithId(object identity);
    }

    public interface IFunctionalState<TParam1, TParam2> : IState
    {
        /// <summary>
        /// 自訂義狀態進入點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> EnterWhen(Func<TParam1, TParam2, bool> condition);
        /// <summary>
        /// 自訂義狀態離開點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> ExitWhen(Func<TParam1, TParam2, bool> condition);

        /// <summary>
        /// 自訂義狀態進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> DoOnEnter(Action<TParam1, TParam2> callback);
        /// <summary>
        /// 自訂義狀態離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> DoOnExit(Action<TParam1, TParam2> callback);

        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity Update)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> DoTick(Action<TParam1, TParam2> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity FixedUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> DoFixedTick(Action<TParam1, TParam2> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity LateUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns> 
        public IFunctionalState<TParam1, TParam2> DoLateTick(Action<TParam1, TParam2> callback);

        /// <summary>
        /// 自訂義狀態Identity設置。
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2> WithId(object identity);
    }

    public interface IFunctionalState<TParam1, TParam2, TParam3> : IState
    {
        /// <summary>
        /// 自訂義狀態進入點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> EnterWhen(Func<TParam1, TParam2, TParam3, bool> condition);
        /// <summary>
        /// 自訂義狀態離開點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> ExitWhen(Func<TParam1, TParam2, TParam3, bool> condition);

        /// <summary>
        /// 自訂義狀態進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> DoOnEnter(Action<TParam1, TParam2, TParam3> callback);
        /// <summary>
        /// 自訂義狀態離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> DoOnExit(Action<TParam1, TParam2, TParam3> callback);

        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity Update)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> DoTick(Action<TParam1, TParam2, TParam3> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity FixedUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> DoFixedTick(Action<TParam1, TParam2, TParam3> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity LateUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns> 
        public IFunctionalState<TParam1, TParam2, TParam3> DoLateTick(Action<TParam1, TParam2, TParam3> callback);

        /// <summary>
        /// 自訂義狀態Identity設置。
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3> WithId(object identity);
    }

    public interface IFunctionalState<TParam1, TParam2, TParam3, TParam4> : IState
    {
        /// <summary>
        /// 自訂義狀態進入點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> EnterWhen(Func<TParam1, TParam2, TParam3, TParam4, bool> condition);
        /// <summary>
        /// 自訂義狀態離開點設立。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> ExitWhen(Func<TParam1, TParam2, TParam3, TParam4, bool> condition);

        /// <summary>
        /// 自訂義狀態進入點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoOnEnter(Action<TParam1, TParam2, TParam3, TParam4> callback);
        /// <summary>
        /// 自訂義狀態離開點執行項目設置。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoOnExit(Action<TParam1, TParam2, TParam3, TParam4> callback);

        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity Update)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoTick(Action<TParam1, TParam2, TParam3, TParam4> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity FixedUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoFixedTick(Action<TParam1, TParam2, TParam3, TParam4> callback);
        /// <summary>
        /// 自訂義狀態更新執行項目設置(Unity LateUpdate)。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns> 
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> DoLateTick(Action<TParam1, TParam2, TParam3, TParam4> callback);

        /// <summary>
        /// 自訂義狀態Identity設置。
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IFunctionalState<TParam1, TParam2, TParam3, TParam4> WithId(object identity);
    }
}
