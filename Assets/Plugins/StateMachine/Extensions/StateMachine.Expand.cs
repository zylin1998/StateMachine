using System;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public static partial class StateMachine
    {
        /// <summary>
        /// 序列狀態機，可透過狀態的Identity排序並依序進行，此方法會以將目標狀態機的轉換強制換成序列轉換，
        /// 僅支持單通道狀態機。
        /// </summary>
        /// <returns></returns>
        public static ISequenceStateMachine Sequence(this IStateMachine self)
        {
            return new SequenceStateMachine(self);
        }

        /// <summary>
        /// 將序列狀態機排序。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="identities">排列後的狀態Identity</param>
        /// <returns></returns>
        public static ISequenceStateMachine OrderBy(this ISequenceStateMachine self, params object[] identities)
        {
            self.OrderBy(new SequenceOrder(identities));

            return self;
        }

        /// <summary>
        /// 將序列狀態機排序。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="identities">排列後的狀態Identity</param>
        /// <returns></returns>
        public static ISequenceStateMachine OrderBy(this ISequenceStateMachine self, IEnumerable<object> identities)
        {
            self.OrderBy(new SequenceOrder(identities));

            return self;
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IPhaseStateMachine Phase(this IStateMachine self)
        {
            return new PhaseStateMachine(self);
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
            return new PhaseStateMachine<T>(self, param1);
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
            return new PhaseStateMachine<T1, T2>(self, param1, param2);
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
            return new PhaseStateMachine<T1, T2, T3>(self, param1, param2, param3);
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
            return new PhaseStateMachine<T1, T2, T3, T4>(self, param1, param2, param3, param4);
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IPhaseStateMachine Phase(this ISequenceStateMachine self)
        {
            return new PhaseStateMachine(self)
                .ExitWhen(() => !self.Active)
                .DoOnExit(() => self.Dispose());
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T> Phase<T>(this ISequenceStateMachine self, T param1)
        {
            return new PhaseStateMachine<T>(self, param1)
                .ExitWhen((param1) => !self.Active)
                .DoOnExit((param1) => self.Dispose());
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <param name="parma2"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> Phase<T1, T2>(this ISequenceStateMachine self, T1 param1, T2 parma2)
        {
            return new PhaseStateMachine<T1, T2>(self, param1, parma2)
                .ExitWhen((param1, param2) => !self.Active)
                .DoOnExit((param1, param2) => self.Dispose());
        }

        /// <summary>
        /// 階層狀態機，包含狀態及狀態機的功能，可作為狀態導入至其他狀態機。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="param1"></param>
        /// <param name="parma2"></param>
        /// <param name="param3"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> Phase<T1, T2, T3>(this ISequenceStateMachine self, T1 param1, T2 parma2, T3 param3)
        {
            return new PhaseStateMachine<T1, T2, T3>(self, param1, parma2, param3)
                .ExitWhen((param1, param2, param3) => !self.Active)
                .DoOnExit((param1, param2, param3) => self.Dispose());
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
        /// <param name="parma2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> Phase<T1, T2, T3, T4>(this ISequenceStateMachine self, T1 param1, T2 parma2, T3 param3, T4 param4)
        {
            return new PhaseStateMachine<T1, T2, T3, T4>(self, param1, parma2, param3, param4)
                .ExitWhen((param1, param2, param3, param4) => !self.Active)
                .DoOnExit((param1, param2, param3, param4) => self.Dispose());
        }

        /// <summary>
        /// 階層狀態機的進出點設定
        /// </summary>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入判斷</param>
        /// <param name="exit">階層狀態機離開判斷</param>
        /// <returns></returns>
        public static IPhaseStateMachine Entrance(this IPhaseStateMachine self, Func<bool> enter, Func<bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機的進出點設定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入判斷</param>
        /// <param name="exit">階層狀態機離開判斷</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T> Entrance<T>(this IPhaseStateMachine<T> self, Func<T, bool> enter, Func<T, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機的進出點設定
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入判斷</param>
        /// <param name="exit">階層狀態機離開判斷</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> Entrance<T1, T2>(this IPhaseStateMachine<T1, T2> self, Func<T1, T2, bool> enter, Func<T1, T2, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機的進出點設定
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入判斷</param>
        /// <param name="exit">階層狀態機離開判斷</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> Entrance<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, Func<T1, T2, T3, bool> enter, Func<T1, T2, T3, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機的進出點設定
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入判斷</param>
        /// <param name="exit">階層狀態機離開判斷</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> Entrance<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, Func<T1, T2, T3, T4, bool> enter, Func<T1, T2, T3, T4, bool> exit)
        {
            if (enter != null) { self.EnterWhen(enter); }
            if (exit  != null) { self.ExitWhen(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機進出時執行項目
        /// </summary>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入執行項目</param>
        /// <param name="exit">階層狀態機離開執行項目</param>
        /// <returns></returns>
        public static IPhaseStateMachine OnEntrance(this IPhaseStateMachine self, Action enter, Action exit)
        {
            if (enter != null) { self.DoOnEnter(enter); }
            if (exit  != null) { self.DoOnExit(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機進出時執行項目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入執行項目</param>
        /// <param name="exit">階層狀態機離開執行項目</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T> OnEntrance<T>(this IPhaseStateMachine<T> self, Action<T> enter, Action<T> exit)
        {
            if (enter != null) { self.DoOnEnter(enter); }
            if (exit  != null) { self.DoOnExit(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機進出時執行項目
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入執行項目</param>
        /// <param name="exit">階層狀態機離開執行項目</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2> OnEntrance<T1, T2>(this IPhaseStateMachine<T1, T2> self, Action<T1, T2> enter, Action<T1, T2> exit)
        {
            if (enter != null) { self.DoOnEnter(enter); }
            if (exit  != null) { self.DoOnExit(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機進出時執行項目
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入執行項目</param>
        /// <param name="exit">階層狀態機離開執行項目</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3> OnEntrance<T1, T2, T3>(this IPhaseStateMachine<T1, T2, T3> self, Action<T1, T2, T3> enter, Action<T1, T2, T3> exit)
        {
            if (enter != null) { self.DoOnEnter(enter); }
            if (exit  != null) { self.DoOnExit(exit);   }

            return self;
        }

        /// <summary>
        /// 階層狀態機進出時執行項目
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="self"></param>
        /// <param name="enter">階層狀態機進入執行項目</param>
        /// <param name="exit">階層狀態機離開執行項目</param>
        /// <returns></returns>
        public static IPhaseStateMachine<T1, T2, T3, T4> OnEntrance<T1, T2, T3, T4>(this IPhaseStateMachine<T1, T2, T3, T4> self, Action<T1, T2, T3, T4> enter, Action<T1, T2, T3, T4> exit)
        {
            if (enter != null) { self.DoOnEnter(enter); }
            if (exit  != null) { self.DoOnExit(exit);   }

            return self;
        }
    }
}
