using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    [Serializable]
    public class InputManager
    {
        [Header("¤è¦VÁä")]
        [SerializeField]
        private KeyCode _DirectUp;
        [SerializeField]
        private KeyCode _DirectDown;
        [SerializeField]
        private KeyCode _DirectLeft;
        [SerializeField]
        private KeyCode _DirectRight;

        [Header("²¾°ÊÁä")]
        [SerializeField]
        private KeyCode _MoveUp;
        [SerializeField]
        private KeyCode _MoveDown;
        [SerializeField]
        private KeyCode _MoveLeft;
        [SerializeField]
        private KeyCode _MoveRight;

        [Header("§ğÀ»Áä")]
        [SerializeField]
        private KeyCode _Attack;

        public float DirectX 
        {
            get 
            {
                if (Input.GetKey(_DirectRight)) { return  1; }
                if (Input.GetKey(_DirectLeft))  { return -1; }

                return 0;
            }
        }

        public float DirectY
        {
            get
            {
                if (Input.GetKey(_DirectUp))   { return  1; }
                if (Input.GetKey(_DirectDown)) { return -1; }

                return 0;
            }
        }

        public float MoveX
        {
            get
            {
                if (Input.GetKey(_MoveRight)) { return  1; }
                if (Input.GetKey(_MoveLeft))  { return -1; }

                return 0;
            }
        }

        public float MoveY
        {
            get
            {
                if (Input.GetKey(_MoveUp))   { return  1; }
                if (Input.GetKey(_MoveDown)) { return -1; }

                return 0;
            }
        }

        public Vector2 Direct => new(DirectX, DirectY);
        public Vector2 Move   => new(MoveX  , MoveY);

        public bool    Attack => Input.GetKey(_Attack);
    }
}
