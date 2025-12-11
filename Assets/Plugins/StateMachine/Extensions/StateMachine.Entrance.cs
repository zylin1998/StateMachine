using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachineX
{
    public static partial class StateMachine
    {
        /// <summary>
        /// 單通道狀態機，只允許同時單一狀態進行。
        /// </summary>
        /// <returns></returns>
        public static IStateMachine SingleEntrance()
        {
            return PoolUtils.GetSingleEntrance();
        }

        /// <summary>
        /// 多通道狀態機，可提供多個狀態同時進行。
        /// </summary>
        /// <returns></returns>
        public static IStateMachine MultiEntrance()
        {
            return PoolUtils.GetMultiEntrance();
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

        /// <summary>
        /// 設定狀態機的Identity
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Identity"></param>
        /// <returns></returns>
        public static IStateMachine WithId(this IStateMachine self, object Identity) 
        {
            self.SetIdentity(Identity);

            return self;
        }

        /// <summary>
        /// 設定節點的Identity
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Identity"></param>
        /// <returns></returns>
        public static IMachineNode WithId(this IMachineNode self, object Identity) 
        {
            self.SetIdentity(Identity);

            return self;
        }

        /// <summary>
        /// 設定狀態的Identity
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Identity"></param>
        /// <returns></returns>
        public static IState WithId(this IState self, object Identity)
        {
            self.SetIdentity(Identity);

            return self;
        }

        /// <summary>
        /// 設置節點的狀態觀察器
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
        public static TNode WithWatcher<TNode>(this TNode node) where TNode : IMachineNode
        {
            if (node.Watcher != null) 
            {
                return node;
            }

            node.SpawnWatcher();

            if (node.HasChild && node is IStateMachine machine) 
            {
                foreach (var state in machine.States) 
                {
                    var watcher = state.WithWatcher().Watcher;
                    
                    if (node.Watcher is MonoBehaviour parent && watcher is MonoBehaviour child) 
                    {
                        child.transform.SetParent(parent.transform);
                    }
                }
            }

            return node;
        }

        /// <summary>
        /// 節點回收
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        public static void Recycle<T>(this T node) where T : IMachineNode 
        {
            PoolUtils.Despawn(node);
        }

        /// <summary>
        /// 節點回收
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="disposeChild">是否釋放子節點</param>
        public static void Recycle<T>(this T node, bool disposeChild) where T : IMachineNode
        {
            PoolUtils.Despawn(node, disposeChild);
        }
    }
}
