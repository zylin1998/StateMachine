using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineX.Editor
{
    public interface INodeParameterDrawer
    {
        public Type DrawType { get; }

        public void Draw(object obj);
    }
}
