using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IStateMachine : IMachineNode
    {
        /// <summary>
        /// 當前狀態。
        /// </summary>
        public IState Current { get; }

        /// <summary>
        /// 狀態清單。
        /// </summary>
        public IEnumerable<IState> States { get; }

        /// <summary>
        /// 是否強制退出狀態。
        /// </summary>
        public bool ForceExit { get; set; }

        /// <summary>
        /// 新增狀態。
        /// </summary>
        /// <param name="state"></param>
        public void Add(IState state);
        /// <summary>
        /// 設置狀態。
        /// </summary>
        /// <param name="state"></param>
        public void Set(IState state);
        /// <summary>
        /// 設置狀態。
        /// </summary>
        /// <param name="identity">目標狀態Id</param>
        public void Set(object identity);
        /// <summary>
        /// 狀態轉換。
        /// </summary>
        /// <returns></returns>
        public bool Transfer();
    }
}
