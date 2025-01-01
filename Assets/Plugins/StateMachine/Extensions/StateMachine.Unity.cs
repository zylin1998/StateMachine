using System;
using System.Linq;
using System.Collections.Generic;
using StateMachine.Internal;
using UnityEngine;

namespace StateMachine
{
    public static partial class StateMachine
    {
        /// <summary>
        /// 讓狀態機以 Unity Update 的方式更新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transfer">是否轉換狀態</param>
        /// <returns></returns>
        public static IDisposable Update(this IStateMachine self, bool transfer = true)
        {
            return MainThreadDispatcher.RegisterUpdate(self, transfer);
        }

        /// <summary>
        /// 讓狀態機以 Unity FixedUpdate 的方式更新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transfer">是否轉換狀態</param>
        /// <returns></returns>
        public static IDisposable FixedUpdate(this IStateMachine self, bool transfer = true)
        {
            return MainThreadDispatcher.RegisterFixedUpdate(self, transfer);
        }

        /// <summary>
        /// 讓狀態機以 Unity LateUpdate 的方式更新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transfer">是否轉換狀態</param>
        /// <returns></returns>
        public static IDisposable LateUpdate(this IStateMachine self, bool transfer = true)
        {
            return MainThreadDispatcher.RegisterLateUpdate(self, transfer);
        }

        /// <summary>
        /// 將跳脫物件掛載到遊戲物件上
        /// </summary>
        /// <param name="self"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static IDisposable AddTo(this IDisposable self, Component component)
        {
            return self.AddTo(component.gameObject);
        }

        /// <summary>
        /// 將跳脫物件掛載到遊戲物件上
        /// </summary>
        /// <param name="self"></param>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static IDisposable AddTo(this IDisposable self, GameObject gameObject) 
        {
            var catcher = gameObject.GetComponent<DisposableCatcher>() ?? gameObject.AddComponent<DisposableCatcher>();

            catcher.Set(self);

            return self;
        }
    }
}
