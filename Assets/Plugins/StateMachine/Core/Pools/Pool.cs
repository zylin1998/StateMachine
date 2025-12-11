using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineX
{
    #region Pools

    public abstract class Pool 
    {
        internal Pool(Factory factory, Type targetType) 
        {
            Factory    = factory;
            TargetType = targetType;

            Queue = new Queue<object>();
        }

        internal Queue<object> Queue { get; }

        internal Factory Factory { get; }

        public Type TargetType { get; }

        public int CreateCount => Factory.CreateCount;

        public int InPoolCount => Queue.Count;

        public virtual object Spawn() 
        {
            if (!Queue.TryDequeue(out var obj))
            {
                obj = Factory.Create();
            }

            return obj;
        }

        public virtual void Despawn(object obj) 
        {
            Queue.Enqueue(obj);
        }
    }

    public class NodePool : Pool
    {
        public NodePool(Type targetType) : base(new NodeFactory(targetType), targetType)
        {
            
        }
    }

    public class WatcherPool : Pool
    {
        public WatcherPool() : base(new WatcherFactory(), typeof(INodeWatcher))
        {
            
        }

        public override void Despawn(object obj)
        {
            if (!(obj is INodeWatcher watcher))
            {
                return;
            }

            Queue.Enqueue(watcher);

#if UNITY_EDITOR
            if (watcher is MonoBehaviour mono)
            {
                mono.name = "NodeWatcher";

                mono.transform.SetParent(StateMachine.GetInternalRoot());

                mono.gameObject.SetActive(false);
            }
#endif
        }
    }

    #endregion
}
