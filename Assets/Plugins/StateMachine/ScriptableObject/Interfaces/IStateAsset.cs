using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public interface IStateAsset 
    {
        public object Id { get; }

        public IState GetState();
    }

    public interface IStateAsset<T>
    {
        public object Id { get; }

        public IState GetState(T param1);
    }

    public interface IStateAsset<T1, T2>
    {
        public object Id { get; }

        public IState GetState(T1 param1, T2 param2);
    }

    public interface IStateAsset<T1, T2, T3>
    {
        public object Id { get; }

        public IState GetState(T1 param1, T2 param2, T3 param3);
    }

    public interface IStateAsset<T1, T2, T3, T4>
    {
        public object Id { get; }

        public IState GetState(T1 param1, T2 param2, T3 param3, T4 param4);
    }
}
