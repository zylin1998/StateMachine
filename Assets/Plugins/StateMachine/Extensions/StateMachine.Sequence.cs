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
            return PoolUtils.GetSequenceStateMachine(self);
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
        /// 設定序列狀態機的Identity
        /// </summary>
        /// <param name="self"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static ISequenceStateMachine WithId(this ISequenceStateMachine self, object identity) 
        {
            self.SetIdentity(identity);
            
            return self;
        }
    }
}
