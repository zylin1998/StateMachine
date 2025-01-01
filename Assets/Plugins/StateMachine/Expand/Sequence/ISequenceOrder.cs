using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
{
    public interface ISequenceOrder
    {
        public IEnumerable<object> Orders { get; }
    }
}
