using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IState : IMachineNode
    {
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
        /// 預設狀態，可避免無效參照被使用
        /// </summary>
        public static IState Default   { get; } = new DefaultState();

        #region Nest Type

        protected class DefaultState : IState
        {
            public object Identity { get; } = DefaultId;

            public bool Enter => false;

            public bool Exit  => true;

            public bool HasChild => false;

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

            public void SetIdentity(object identity) 
            {

            }

            public void Reset() 
            {

            }

            public void Dispose(bool disposeChild)
            {

            }

            public void Dispose() 
            {

            }
        }

        #endregion
    }
}
