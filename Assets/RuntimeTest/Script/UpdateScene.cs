using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineX.RuntimeTest
{
    public class UpdateScene : MonoBehaviour
    {
        [Serializable]
        private enum EUpdateMode 
        {
            Update,
            FixedUpdate,
            LateUpdate,
        }

        [SerializeField]
        private Text _Text;
        [SerializeField]
        private EUpdateMode _UpdateMode;

        public Vector3 Direct { get; private set; }

        public IStateMachine Machine { get; private set; }  
        
        public IMachineRegistration Register { get; private set; }

        private void Awake()
        {
            var idle = StateMachine.FunctionalState()
                .EnterWhen(() => Direct == Vector3.zero)
                .DoTick(Idle)
                .DoFixedTick(Idle)
                .DoLateTick(Idle);

            var move = StateMachine.FunctionalState()
                .EnterWhen(() => Direct != Vector3.zero)
                .DoTick(Moving)
                .DoFixedTick(Moving)
                .DoLateTick(Moving);

            Machine = StateMachine
                .SingleEntrance()
                .WithStates(idle, move);
        }

        private void OnEnable()
        {
            if (_UpdateMode == EUpdateMode.Update     ) { Register = Machine.Update();      }
            if (_UpdateMode == EUpdateMode.FixedUpdate) { Register = Machine.FixedUpdate(); }
            if (_UpdateMode == EUpdateMode.LateUpdate ) { Register = Machine.LateUpdate();  }

            Register.AddTo(this);
        }

        private void OnDisable()
        {
            Register?.Dispose();
        }

        private void Update()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            
            Direct = new(x, y, 0);
        }

        public void Moving() 
        {
            _Text.text = "Moving";
        }

        public void Idle() 
        {
            _Text.text = "Idle";
        }
    }
}