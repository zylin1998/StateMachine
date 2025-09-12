using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface ISequenceStateMachine : IStateMachine
    {
        /// <summary>
        /// 是否循環。
        /// </summary>
        public bool Cycle  { get; set; }

        /// <summary>
        /// 狀態機是否執行中
        /// </summary>
        public bool Active { get; }

        /// <summary>
        /// 是否忽略進入點
        /// </summary>
        public bool IgnoreEnter { get; set; }

        /// <summary>
        /// 將序列狀態機排序。
        /// </summary>
        /// <param name="order">Id 序列介面</param>
        public void OrderBy(ISequenceOrder order);
    }
}
