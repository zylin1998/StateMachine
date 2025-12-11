using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineX
{
    public static partial class StateMachine
    {
        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IPhaseStateMachine Phase(this IStateMachine self)
        {
            return PoolUtils.GetPhaseStateMachine(self);
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T> Phase<T>(this IStateMachine self, T param1)
        {
            return PoolUtils.GetPhaseStateMachine(self, param1);
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> Phase<T1, T2>(this IStateMachine self, T1 param1, T2 param2)
        {
            return PoolUtils.GetPhaseStateMachine(self, param1, param2);
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> Phase<T1, T2, T3>(this IStateMachine self, T1 param1, T2 param2, T3 param3)
        {
            return PoolUtils.GetPhaseStateMachine(self, param1, param2, param3);
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> Phase<T1, T2, T3, T4>(this IStateMachine self, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            return PoolUtils.GetPhaseStateMachine(self, param1, param2, param3, param4);
        }

        /// <summary>
        /// 設定階層狀態機進入條件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine EnterWhen(this IPhaseStateMachine self, Func<bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1> EnterWhen<T1>(this IPhaseStateMachine<T1> self, Func<T1, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> EnterWhen<T1, T2>(this IPhaseStateMachine<T1, T2> self, Func<T1, T2, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> EnterWhen<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, Func<T1, T2, T3, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> EnterWhen<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, Func<T1, T2, T3, T4, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開條件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine ExitWhen(this IPhaseStateMachine self, Func<bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1> ExitWhen<T1>(this IPhaseStateMachine<T1> self, Func<T1, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> ExitWhen<T1, T2>(this IPhaseStateMachine<T1, T2> self, Func<T1, T2, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> ExitWhen<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, Func<T1, T2, T3, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開條件
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> ExitWhen<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, Func<T1, T2, T3, T4, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入動作
        /// </summary>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine DoOnEnter(this IPhaseStateMachine self, Action callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1> DoOnEnter<T1>(this IPhaseStateMachine<T1> self, Action<T1> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> DoOnEnter<T1, T2>(this IPhaseStateMachine<T1, T2> self, Action<T1, T2> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> DoOnEnter<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機進入動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> DoOnEnter<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開動作
        /// </summary>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine DoOnExit(this IPhaseStateMachine self, Action callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1> DoOnExit<T1>(this IPhaseStateMachine<T1> self, Action<T1> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> DoOnExit<T1, T2>(this IPhaseStateMachine<T1, T2> self, Action<T1, T2> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> DoOnExit<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機離開動作
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> DoOnExit<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        /// <summary>
        /// 設定階層狀態機的Identity
        /// </summary>
        /// <param name="self"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static IPhaseStateMachine WithId(this IPhaseStateMachine self, object identity) 
        {
            self.SetIdentity(identity);

            return self;
        }

        /// <summary>
        /// 設定階層狀態機的Identity
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="self"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1> WithId<T1>(this IPhaseStateMachine<T1> self, object identity)
        {
            self.SetIdentity(identity);

            return self;
        }

        /// <summary>
        /// 設定階層狀態機的Identity
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> WithId<T1, T2>(this IPhaseStateMachine<T1, T2> self, object identity)
        {
            self.SetIdentity(identity);

            return self;
        }

        /// <summary>
        /// 設定階層狀態機的Identity
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> WithId<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, object identity)
        {
            self.SetIdentity(identity);

            return self;
        }

        /// <summary>
        /// 設定階層狀態機的Identity
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> WithId<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, object identity)
        {
            self.SetIdentity(identity);

            return self;
        }
    }
}
