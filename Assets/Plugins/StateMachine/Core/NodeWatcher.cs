using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX
{
    public class NodeWatcher : INodeWatcher
    {
        private IMachineNode _Node;

        private bool _IsCurrent;
        
        private float _StartTime;
        private float _StartFrame;

        public IMachineNode Node => _Node;

        public bool IsCurrent => _IsCurrent;

        public float StartTime  => _StartTime;
        public float PassTime   => _IsCurrent ? Time.realtimeSinceStartup - StartTime : 0f;
        public float StartFrame => _StartFrame;
        public float PassFrame  => _IsCurrent ? Time.frameCount - StartFrame : 0f;

        public INodeWatcher ByNode(IMachineNode node)
        {
            _Node = node;

            return this;
        }

        public void StartWatch()
        {
            _IsCurrent = true;

            _StartTime  = Time.realtimeSinceStartup;
            _StartFrame = Time.frameCount;
        }

        public void StopWatch()
        {
            _IsCurrent = false;

            _StartTime  = 0;
            _StartFrame = 0;

            if (Node.HasChild && Node is IStateMachine machine)
            {
                var current = machine.Current;

                if (current is IEnumerable<IState> states)
                {
                    foreach (var state in states)
                    {
                        state.Watcher.StopWatch();
                    }
                }

                else
                {
                    current?.Watcher?.StopWatch();
                }
            }
        }
    }
}
