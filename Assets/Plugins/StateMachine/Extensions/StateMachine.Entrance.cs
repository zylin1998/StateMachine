using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    public static partial class StateMachine
    {
        /// <summary>
        /// 單通道狀態機，只允許同時單一狀態進行。
        /// </summary>
        /// <returns></returns>
        public static IStateMachine SingleEntrance()
        {
            return new SingleEntrance();
        }

        /// <summary>
        /// 多通道狀態機，可提供多個狀態同時進行。
        /// </summary>
        /// <returns></returns>
        public static IStateMachine MultiEntrance()
        {
            return new MultiEntrance();
        }

        /// <summary>
        /// 放入狀態機所需的狀態。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="states">狀態清單</param>
        /// <returns></returns>
        public static IStateMachine WithStates(this IStateMachine self, params IState[] states)
        {
            foreach (var state in states)
            {
                self.Add(state);
            }

            return self;
        }

        /// <summary>
        /// 放入狀態機所需的狀態。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="states">狀態清單</param>
        /// <returns></returns>
        public static IStateMachine WithStates(this IStateMachine self, IEnumerable<IState> states)
        {
            foreach (var state in states)
            {
                self.Add(state);
            }

            return self;
        }
    }
}
