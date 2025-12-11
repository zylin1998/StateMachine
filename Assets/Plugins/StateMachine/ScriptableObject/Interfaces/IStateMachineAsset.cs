using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IStateMachineAsset
    {
        public object Id { get; }

        public IStateMachine GetMachine();
    }

    public interface IStateMachineAsset<T>
    {
        public object Id { get; }

        public IStateMachine GetMachine(T param1);
    }

    public interface IStateMachineAsset<T1, T2>
    {
        public object Id { get; }

        public IStateMachine GetMachine(T1 param1, T2 param2);
    }

    public interface IStateMachineAsset<T1, T2, T3>
    {
        public object Id { get; }

        public IStateMachine GetMachine(T1 param1, T2 param2, T3 param3);
    }

    public interface IStateMachineAsset<T1, T2, T3, T4>
    {
        public object Id { get; }

        public IStateMachine GetMachine(T1 param1, T2 param2, T3 param3, T4 param4);
    }
}
