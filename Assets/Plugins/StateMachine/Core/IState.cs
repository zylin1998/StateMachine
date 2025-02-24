using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IState
    {
        /// <summary>
        /// 狀態Id。
        /// </summary>
        public object Identity { get; }

        /// <summary>
        /// 狀態進入點判定。
        /// </summary>
        public bool Enter { get; }
        /// <summary>
        /// 狀態離開點判定。
        /// </summary>
        public bool Exit  { get; }

        /// <summary>
        /// 狀態進入點執行項目。
        /// </summary>
        public void OnEnter();
        /// <summary>
        /// 狀態進入點執行項目。
        /// </summary>
        public void OnExit();

        /// <summary>
        /// 狀態更新(Unity Update)。
        /// </summary>
        public void Tick();
        /// <summary>
        /// 狀態更新(Unity FixedUpdate)。
        /// </summary>
        public void FixedTick();
        /// <summary>
        /// 狀態更新(Unity LateUpdate)。
        /// </summary>
        public void LateTick();

        public static IState Default   { get; } = new DefaultState();

        protected static object DefaultId { get; } = new DefaultIdentity();

        protected class DefaultIdentity 
        {
            public override string ToString()
            {
                return "DefaultState";
            }
        }

        protected class DefaultState : IState
        {
            public object Identity { get; } = DefaultId;

            public bool Enter => false;

            public bool Exit  => true;

            public void OnEnter()
            {
                
            }

            public void OnExit()
            {
                
            }

            public void Tick()
            {
                
            }

            public void FixedTick()
            {
                
            }

            public void LateTick()
            {
                
            }
        }
    }
}
