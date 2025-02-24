using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineX.SampleGame
{
    public class Life : MonoBehaviour
    {
        [SerializeField]
        private Text _Text;

        public void Set(int life) 
        {
            _Text.text = "X" + (life >= 0 ? life: 0);
        }
    }
}
