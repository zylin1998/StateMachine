using System;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public static partial class StateMachine
    {
        /// <summary>
        /// �إߦۭq�q���A
        /// </summary>
        /// <returns></returns>
        public static IFunctionalState FunctionalState()
        {
            return new FunctionalState();
        }

        /// <summary>
        /// �إߦۭq�q���A
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IFunctionalState<T> FunctionalState<T>(T param) 
        {
            return new FunctionalState<T>(param);
        }

        /// <summary>
        /// �إߦۭq�q���A
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2> FunctionalState<T1, T2>(T1 param1, T2 param2)
        {
            return new FunctionalState<T1, T2>(param1, param2);
        }

        /// <summary>
        /// �إߦۭq�q���A
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3> FunctionalState<T1, T2, T3>(T1 param1, T2 param2, T3 param3)
        {
            return new FunctionalState<T1, T2, T3>(param1, param2, param3);
        }

        /// <summary>
        /// �إߦۭq�q���A
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3, T4> FunctionalState<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            return new FunctionalState<T1, T2, T3, T4>(param1, param2, param3, param4);
        }

        public static IFunctionalState EnterWhen(this IFunctionalState self, Func<bool> condition) 
        {
            self.EnterEvent = condition;

            return self;
        }

        public static IFunctionalState<T1> EnterWhen<T1>(this IFunctionalState<T1> self, Func<T1,bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        public static IFunctionalState<T1, T2> EnterWhen<T1, T2>(this IFunctionalState<T1, T2> self, Func<T1, T2, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> EnterWhen<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Func<T1, T2, T3, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> EnterWhen<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Func<T1, T2, T3, T4, bool> condition)
        {
            self.EnterEvent = condition;

            return self;
        }

        public static IFunctionalState ExitWhen(this IFunctionalState self, Func<bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        public static IFunctionalState<T1> ExitWhen<T1>(this IFunctionalState<T1> self, Func<T1, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        public static IFunctionalState<T1, T2> ExitWhen<T1, T2>(this IFunctionalState<T1, T2> self, Func<T1, T2, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> ExitWhen<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Func<T1, T2, T3, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> ExitWhen<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Func<T1, T2, T3, T4, bool> condition)
        {
            self.ExitEvent = condition;

            return self;
        }

        public static IFunctionalState DoOnEnter(this IFunctionalState self, Action callback) 
        {
            self.OnEnterEvent = callback;

            return self;
        }

        public static IFunctionalState<T1> DoOnEnter<T1>(this IFunctionalState<T1> self, Action<T1> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2> DoOnEnter<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> DoOnEnter<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> DoOnEnter<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.OnEnterEvent = callback;

            return self;
        }

        public static IFunctionalState DoOnExit(this IFunctionalState self, Action callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        public static IFunctionalState<T1> DoOnExit<T1>(this IFunctionalState<T1> self, Action<T1> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2> DoOnExit<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> DoOnExit<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> DoOnExit<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.OnExitEvent = callback;

            return self;
        }

        public static IFunctionalState DoTick(this IFunctionalState self, Action callback)
        {
            self.TickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1> DoTick<T1>(this IFunctionalState<T1> self, Action<T1> callback)
        {
            self.TickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2> DoTick<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> callback)
        {
            self.TickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> DoTick<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.TickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> DoTick<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.TickEvent = callback;

            return self;
        }

        public static IFunctionalState DoFixedTick(this IFunctionalState self, Action callback)
        {
            self.FixedTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1> DoFixedTick<T1>(this IFunctionalState<T1> self, Action<T1> callback)
        {
            self.FixedTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2> DoFixedTick<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> callback)
        {
            self.FixedTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> DoFixedTick<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.FixedTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> DoFixedTick<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.FixedTickEvent = callback;

            return self;
        }

        public static IFunctionalState DoLateTick(this IFunctionalState self, Action callback)
        {
            self.LateTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1> DoLateTick<T1>(this IFunctionalState<T1> self, Action<T1> callback)
        {
            self.LateTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2> DoLateTick<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> callback)
        {
            self.LateTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3> DoLateTick<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> callback)
        {
            self.LateTickEvent = callback;

            return self;
        }

        public static IFunctionalState<T1, T2, T3, T4> DoLateTick<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> callback)
        {
            self.LateTickEvent = callback;

            return self;
        }
    }
}
