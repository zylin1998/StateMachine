using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX
{
    public interface INodeWatcher
    {
        public IMachineNode Node { get; }

        public bool  IsCurrent  { get; }

        public float StartTime  { get; }
        public float PassTime   { get; }
        public float StartFrame { get; }
        public float PassFrame  { get; }

        public void StartWatch();

        public void StopWatch();
    }
}
