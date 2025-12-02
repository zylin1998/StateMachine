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
            return NodePool.GetSingleEntrance();
        }

        /// <summary>
        /// 多通道狀態機，可提供多個狀態同時進行。
        /// </summary>
        /// <returns></returns>
        public static IStateMachine MultiEntrance()
        {
            return NodePool.GetMultiEntrance();
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

        public static IStateMachine WithId(this IStateMachine self, object Identity) 
        {
            self.SetIdentity(Identity);

            return self;
        }

        public static IMachineNode WithId(this IMachineNode self, object Identity) 
        {
            self.SetIdentity(Identity);

            return self;
        }

        public static IState WithId(this IState self, object Identity)
        {
            self.SetIdentity(Identity);

            return self;
        }


        public static TNode WithWatcher<TNode>(this TNode node) where TNode : IMachineNode
        {
#if UNITY_EDITOR
            node.Watcher = new GameObject(node.Identity?.ToString())
                .AddComponent<MonoNodeWatcher>()
                .ByNode(node);
#else
            state.Watcher = new StateWatcher().ByState(state);
#endif

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

        public static void Recycle<T>(this T node) where T : IMachineNode 
        {
            NodePool.Despawn(node);
        }

        public static void Recycle<T>(this T node, bool disposeChild) where T : IMachineNode
        {
            NodePool.Despawn(node, disposeChild);
        }
    }
}
