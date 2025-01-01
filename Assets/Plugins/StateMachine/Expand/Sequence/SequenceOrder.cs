using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine
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
