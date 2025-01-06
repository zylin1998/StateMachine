using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateAssetBase : ScriptableObject, IStateAsset
    {
        [SerializeField]
        protected string _Id;

        public object Id => _Id;

        public abstract IState GetState();
    }

    public abstract class StateAssetBase<T> : ScriptableObject, IStateAsset<T>
    {
        [SerializeField]
        protected string _Id;

        public object Id => _Id;

        public abstract IState GetState(T param1);
    }

    public abstract class StateAssetBase<T1, T2> : ScriptableObject, IStateAsset<T1, T2>
    {
        [SerializeField]
        protected string _Id;

        public object Id => _Id;

        public abstract IState GetState(T1 param1, T2 param2);
    }

    public abstract class StateAssetBase<T1, T2, T3> : ScriptableObject, IStateAsset<T1, T2, T3>
    {
        [SerializeField]
        protected string _Id;

        public object Id => _Id;

        public abstract IState GetState(T1 param1, T2 param2, T3 param3);
    }

    public abstract class StateAssetBase<T1, T2, T3, T4> : ScriptableObject, IStateAsset<T1, T2, T3, T4>
    {
        [SerializeField]
        protected string _Id;

        public object Id => _Id;

        public abstract IState GetState(T1 param1, T2 param2, T3 param3, T4 param4);
    }
}
