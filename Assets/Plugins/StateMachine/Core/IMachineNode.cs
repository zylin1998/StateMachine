using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineX
{
    public interface IMachineNode : IDisposable
    {
        /// <summary>
        /// 狀態Id。
        /// </summary>
        public object Identity { get; }
        /// <summary>
        /// 是否包含子節點
        /// </summary>
        public bool HasChild { get; }

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
        /// <summary>
        /// 設置Id
        /// </summary>
        /// <param name="identity"></param>
        public void SetIdentity(object identity);
        /// <summary>
        /// 重置節點
        /// </summary>
        public void Reset();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposeChild"></param>
        public void Dispose(bool disposeChild);

        protected static object DefaultId { get; } = new DefaultIdentity();

        protected class DefaultIdentity
        {
            public override string ToString()
            {
                return "DefaultState";
            }
        }
    }

    public interface IWrappableMachine
    {
        public IStateMachine Core { get; }

        public void SetCore(IStateMachine machine);
    }
}
