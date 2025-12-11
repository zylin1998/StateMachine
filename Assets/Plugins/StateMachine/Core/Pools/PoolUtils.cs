using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineX
{
    public static class PoolUtils
    {
        public static Dictionary<Type, NodePool> Pools { get; } = new();

        public static WatcherPool WatcherPool { get; } = new();

        internal static T As<T>(this object self) 
        {
            if (self is T result) 
            {
                return result;
            }

            return default;
        }

        internal static NodePool GetPool<T>() 
        {
            return GetPool(typeof(T));
        }

        internal static NodePool GetPool(Type type)
        {
            if (!Pools.TryGetValue(type, out var pool))
            {
                pool = new NodePool(type);

                Pools.Add(type, pool);
            }

            return pool;
        }

        public static INodeWatcher SpawnWatcher<TNode>(this TNode node) where TNode : IMachineNode 
        {
            if (node.Watcher != null) 
            {
                return node.Watcher.ByNode(node);
            }

            node.Watcher = WatcherPool.Spawn().As<INodeWatcher>().ByNode(node);

            return node.Watcher;
        }

        public static T Spawn<T>() where T : IMachineNode
        {
            var pool = GetPool<T>();

            return (T)pool.Spawn();
        }

        public static T Spawn<T>(IStateMachine stateMachine) where T : IMachineNode, IWrappableMachine
        {
            var pool = GetPool<T>();

            var result = pool.Spawn();
            
            ((IWrappableMachine)result).SetCore(stateMachine);

            return (T)result;
        }

        public static void Despawn(INodeWatcher nodeWatcher) 
        {
            WatcherPool.Despawn(nodeWatcher);
        }

        public static void Despawn<T>(T node) where T : IMachineNode
        {
            Despawn(node, true);
        }

        public static void Despawn<T>(T node, bool disposeChild) where T : IMachineNode 
        {
            var pool = GetPool(node.GetType());

            node.Dispose(disposeChild);

            pool.Despawn(node);

            Despawn(node?.Watcher);

            node.Watcher = default;
        }

        public static IFunctionalState GetFunctionalState() 
        {
            return Spawn<FunctionalState>();
        }

        public static IFunctionalState<T1> GetFunctionalState<T1>(T1 param1)
        {
            var node = Spawn<FunctionalState<T1>>();

            node.SetParameters(param1);

            return node;
        }

        public static IFunctionalState<T1, T2> GetFunctionalState<T1, T2>(T1 param1, T2 param2)
        {
            var node = Spawn<FunctionalState<T1, T2>>();

            node.SetParameters(param1, param2);

            return node;
        }

        public static IFunctionalState<T1, T2, T3> GetFunctionalState<T1, T2, T3>(T1 param1, T2 param2, T3 param3)
        {
            var node = Spawn<FunctionalState<T1, T2, T3>>();

            node.SetParameters(param1, param2, param3);

            return node;
        }

        public static IFunctionalState<T1, T2, T3, T4> GetFunctionalState<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var node = Spawn<FunctionalState<T1, T2, T3, T4>>();

            node.SetParameters(param1, param2, param3, param4);

            return node;
        }

        public static IStateMachine GetSingleEntrance() 
        {
            return Spawn<SingleEntrance>();
        }

        public static IStateMachine GetMultiEntrance()
        {
            return Spawn<MultiEntrance>();
        }

        public static ISequenceStateMachine GetSequenceStateMachine(IStateMachine stateMachine)
        {
            return Spawn<SequenceStateMachine>(stateMachine);
        }

        public static IPhaseStateMachine GetPhaseStateMachine(IStateMachine stateMachine)
        {
            return Spawn<PhaseStateMachine>(stateMachine);
        }

        public static IPhaseStateMachine<T1> GetPhaseStateMachine<T1>(IStateMachine stateMachine, T1 param1)
        {
            var node = Spawn<PhaseStateMachine<T1>>(stateMachine);

            node.SetParameters(param1);

            return node;
        }

        public static IPhaseStateMachine<T1, T2> GetPhaseStateMachine<T1, T2>(IStateMachine stateMachine, T1 param1, T2 param2)
        {
            var node = Spawn<PhaseStateMachine<T1, T2>>(stateMachine);

            node.SetParameters(param1, param2);

            return node;
        }

        public static IPhaseStateMachine<T1, T2, T3> GetPhaseStateMachine<T1, T2, T3>(IStateMachine stateMachine, T1 param1, T2 param2, T3 param3)
        {
            var node = Spawn<PhaseStateMachine<T1, T2, T3>>(stateMachine);

            node.SetParameters(param1, param2, param3);

            return node;
        }

        public static IPhaseStateMachine<T1, T2, T3, T4> GetPhaseStateMachine<T1, T2, T3, T4>(IStateMachine stateMachine, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var node = Spawn<PhaseStateMachine<T1, T2, T3, T4>>(stateMachine);

            node.SetParameters(param1, param2, param3, param4);

            return node;
        }
    }
}
