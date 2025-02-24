using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public class SequenceOrder : ISequenceOrder
    {
        public SequenceOrder(params object[] orders) 
        {
            Orders = orders;
        }

        public SequenceOrder(IEnumerable<object> orders)
        {
            Orders = orders;
        }

        public IEnumerable<object> Orders { get; }
    }
}
