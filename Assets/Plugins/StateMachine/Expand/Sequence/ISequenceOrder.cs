using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface ISequenceOrder
    {
        public IEnumerable<object> Orders { get; }
    }
}
