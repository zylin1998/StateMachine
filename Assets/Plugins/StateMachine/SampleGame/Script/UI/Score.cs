using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineX.SampleGame
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        private Text _Text;

        public void Set(int score) 
        {
            _Text.text = score.ToString();
        }
    }
}
