using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineX
{
    public static class NodePool
    {
        #region Nest Type

        internal class Factory
        {
            public Factory(Type targetType)
            {
                TargetType = targetType;
            }

            private int _CreatedCount;

            public Type TargetType { get; }

            public int CreateCount => _CreatedCount;

            public object Create() 
            {
                _CreatedCount++;

                return Activator.CreateInstance(TargetType);
            }
        }

        public class Pool 
        {
            public Pool(Type targetType) 
            {
                var baseType = typeof(IMachineNode);

                if (!baseType.IsAssignableFrom(targetType))
                {
                    DebugHelper.Log(string.Format("Target type ({0}) must have inherit interface of type ({1})", targetType.Name, baseType.Name));
                }

                Factory = new Factory(targetType);

                Queue = new Queue<IMachineNode>();
            }

            internal Factory Factory { get; }

            internal Queue<IMachineNode> Queue { get; }

            public int CreateCount => Factory.CreateCount;

            public int InPoolCount => Queue.Count;

            public IMachineNode Spawn() 
            {
                if (!Queue.TryDequeue(out var node))
                {
                    node = Factory.Create() as IMachineNode;
                }

                return node;
            }

            public void Despawn(IMachineNode node) 
            {
                Queue.Enqueue(node);
            }
        }

        #endregion

        public static Dictionary<Type, Pool> Pools { get; } = new();

        internal static Pool GetPool<T>() 
        {
            var type = typeof(T);

            if (!Pools.TryGetValue(type, out var pool)) 
            {
                pool = new Pool(type);

                Pools.Add(type, pool);
            }

            return pool;
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

        public static void Despawn<T>(T node) where T : IMachineNode
        {
            Despawn(node, true);
        }

        public static void Despawn<T>(T node, bool disposeChild) where T : IMachineNode 
        {
            var pool = GetPool<T>();

            node.Dispose(disposeChild);

            pool.Despawn(node);
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
