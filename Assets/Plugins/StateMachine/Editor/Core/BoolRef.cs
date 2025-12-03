using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineX.Editor
{
    internal class BoolRef
    {
        internal BoolRef() : this(false)
        {

        }

        internal BoolRef(bool value) 
        {
            Value = value;
        }

        internal bool Value { get; set; }

        public static implicit operator bool(BoolRef reference) 
        {
            return reference.Value;
        }
    }
}
