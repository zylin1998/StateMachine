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

        public void SetIdentity(object identity);

        protected static object DefaultId { get; } = new DefaultIdentity();

        protected class DefaultIdentity
        {
            public override string ToString()
            {
                return "DefaultState";
            }
        }

    }
}
