﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineX.Internal;

namespace StateMachineX
{
    public static partial class StateMachine
    {
        /// <summary>
        /// 讓狀態機以 Unity Update 的方式更新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transfer">是否轉換狀態</param>
        /// <returns></returns>
        public static IMachineRegistration Update(this IStateMachine self)
        {
            return MainThreadDispatcher.RegisterUpdate(self);
        }

        /// <summary>
        /// 讓狀態機以 Unity FixedUpdate 的方式更新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transfer">是否轉換狀態</param>
        /// <returns></returns>
        public static IMachineRegistration FixedUpdate(this IStateMachine self)
        {
            return MainThreadDispatcher.RegisterFixedUpdate(self);
        }

        /// <summary>
        /// 讓狀態機以 Unity LateUpdate 的方式更新
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transfer">是否轉換狀態</param>
        /// <returns></returns>
        public static IMachineRegistration LateUpdate(this IStateMachine self)
        {
            return MainThreadDispatcher.RegisterLateUpdate(self);
        }

        public static IMachineRegistration Update(this IMachineRegistration self) 
        {
            return MainThreadDispatcher.RegisterUpdate(self);
        }

        public static IMachineRegistration FixedUpdate(this IMachineRegistration self)
        {
            return MainThreadDispatcher.RegisterFixedUpdate(self);
        }

        public static IMachineRegistration LateUpdate(this IMachineRegistration self)
        {
            return MainThreadDispatcher.RegisterLateUpdate(self);
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
