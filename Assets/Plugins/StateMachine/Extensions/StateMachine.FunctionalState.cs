using System;
using System.Collections;
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

        /// <summary>
        /// �ۭq�q���A���i�X�I�]�w
        /// </summary>
        /// <param name="self"></param>
        /// <param name="enter">�ۭq�q���A�i�J�P�_</param>
        /// <param name="exit">�ۭq�q���A���}�P�_</param>
        /// <returns></returns>
        public static IFunctionalState Entrance(this IFunctionalState self, Func<bool> enter, Func<bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(enter); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A���i�X�I�]�w
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">�ۭq�q���A�i�J�P�_</param>
        /// <param name="exit">�ۭq�q���A���}�P�_</param>
        /// <returns></returns>
        public static IFunctionalState<T1> Entrance<T1>(this IFunctionalState<T1> self, Func<T1, bool> enter, Func<T1, bool> exit) 
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen (enter); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A���i�X�I�]�w
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">�ۭq�q���A�i�J�P�_</param>
        /// <param name="exit">�ۭq�q���A���}�P�_</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2> Entrance<T1, T2>(this IFunctionalState<T1, T2> self, Func<T1, T2, bool> enter, Func<T1, T2, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(enter);  }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A���i�X�I�]�w
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">�ۭq�q���A�i�J�P�_</param>
        /// <param name="exit">�ۭq�q���A���}�P�_</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3> Entrance<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Func<T1, T2, T3, bool> enter, Func<T1, T2, T3, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen (enter); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A���i�X�I�]�w
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">�ۭq�q���A�i�J�P�_</param>
        /// <param name="exit">�ۭq�q���A���}�P�_</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3, T4> Entrance<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Func<T1, T2, T3, T4, bool> enter, Func<T1, T2, T3, T4, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(enter);  }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A�i�X�ɰ��涵��
        /// </summary>
        /// <param name="self"></param>
        /// <param name="onEnter">�ۭq�q���A�i�J�ɰ��涵��</param>
        /// <param name="onExit">�ۭq�q���A���}�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState OnEntrance(this IFunctionalState self, Action onEnter, Action onExit)
        {
            if (onEnter != null) { self.DoOnEnter(onEnter); }
            if (onExit  != null) { self.DoOnExit(onExit); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A�i�X�ɰ��涵��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="onEnter">�ۭq�q���A�i�J�ɰ��涵��</param>
        /// <param name="onExit">�ۭq�q���A���}�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T> OnEntrance<T>(this IFunctionalState<T> self, Action<T> onEnter, Action<T> onExit)
        {
            if (onEnter != null) { self.DoOnEnter(onEnter); }
            if (onExit  != null) { self.DoOnExit(onExit);   }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A�i�X�ɰ��涵��
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="onEnter">�ۭq�q���A�i�J�ɰ��涵��</param>
        /// <param name="onExit">�ۭq�q���A���}�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2> OnEntrance<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> onEnter, Action<T1, T2> onExit)
        {
            if (onEnter != null) { self.DoOnEnter(onEnter); }
            if (onExit  != null) { self.DoOnExit(onExit);   }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A�i�X�ɰ��涵��
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="onEnter">�ۭq�q���A�i�J�ɰ��涵��</param>
        /// <param name="onExit">�ۭq�q���A���}�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3> OnEntrance<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> onEnter, Action<T1, T2, T3> onExit)
        {
            if (onEnter != null) { self.DoOnEnter(onEnter); }
            if (onExit  != null) { self.DoOnExit(onExit);   }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A�i�X�ɰ��涵��
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="onEnter">�ۭq�q���A�i�J�ɰ��涵��</param>
        /// <param name="onExit">�ۭq�q���A���}�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3, T4> OnEntrance<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> onEnter, Action<T1, T2, T3, T4> onExit)
        {
            if (onEnter != null) { self.DoOnEnter(onEnter); }
            if (onExit  != null) { self.DoOnExit(onExit);   }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A��s�ɰ��涵��
        /// </summary>
        /// <param name="self"></param>
        /// <param name="tick">Unity Update ��s�ɰ��涵��</param>
        /// <param name="fixedTick">Unity FixedUpdate ��s�ɰ��涵��</param>
        /// <param name="lateTick">Unity LateUpdate ��s�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState Tick(this IFunctionalState self, Action tick, Action fixedTick, Action lateTick)
        {
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A��s�ɰ��涵��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="tick">Unity Update ��s�ɰ��涵��</param>
        /// <param name="fixedTick">Unity FixedUpdate ��s�ɰ��涵��</param>
        /// <param name="lateTick">Unity LateUpdate ��s�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T> Tick<T>(this IFunctionalState<T> self, Action<T> tick, Action<T> fixedTick, Action<T> lateTick)
        {
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A��s�ɰ��涵��
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="tick">Unity Update ��s�ɰ��涵��</param>
        /// <param name="fixedTick">Unity FixedUpdate ��s�ɰ��涵��</param>
        /// <param name="lateTick">Unity LateUpdate ��s�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2> Tick<T1, T2>(this IFunctionalState<T1, T2> self, Action<T1, T2> tick, Action<T1, T2> fixedTick, Action<T1, T2> lateTick)
        {
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A��s�ɰ��涵��
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="tick">Unity Update ��s�ɰ��涵��</param>
        /// <param name="fixedTick">Unity FixedUpdate ��s�ɰ��涵��</param>
        /// <param name="lateTick">Unity LateUpdate ��s�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3> Tick<T1, T2, T3>(this IFunctionalState<T1, T2, T3> self, Action<T1, T2, T3> tick, Action<T1, T2, T3> fixedTick, Action<T1, T2, T3> lateTick)
        {
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }

            return self;
        }

        /// <summary>
        /// �ۭq�q���A��s�ɰ��涵��
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="tick">Unity Update ��s�ɰ��涵��</param>
        /// <param name="fixedTick">Unity FixedUpdate ��s�ɰ��涵��</param>
        /// <param name="lateTick">Unity LateUpdate ��s�ɰ��涵��</param>
        /// <returns></returns>
        public static IFunctionalState<T1, T2, T3, T4> Tick<T1, T2, T3, T4>(this IFunctionalState<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> tick, Action<T1, T2, T3, T4> fixedTick, Action<T1, T2, T3, T4> lateTick)
        {
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }
            if (tick != null) { self.DoTick(tick); }

            return self;
        }
    }
}
