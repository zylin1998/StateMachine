using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineX
{

    #region Factories

    internal abstract class Factory
    {
        protected int _CreatedCount;

        public int CreateCount => _CreatedCount;

        public abstract object Create();
    }

    internal class NodeFactory : Factory
    {
        public NodeFactory(Type targetType)
        {
            var baseType = typeof(IMachineNode);

            if (!baseType.IsAssignableFrom(targetType))
            {
                DebugHelper.Log("Target type ({0}) must have inherit interface of type ({1})", targetType.Name, baseType.Name);
            }

            TargetType = targetType;
        }

        public Type TargetType { get; }

        public override object Create()
        {
            _CreatedCount++;

            return Activator.CreateInstance(TargetType);
        }
    }

    internal class WatcherFactory : Factory
    {
        public override object Create()
        {
            _CreatedCount++;

            var watcher = default(INodeWatcher);
#if UNITY_EDITOR
            watcher = new GameObject("NodeWatcher").AddComponent<MonoNodeWatcher>();
#else
                watcher = new NodeWatcher();
#endif

            return watcher;
        }
    }

    #endregion
}
