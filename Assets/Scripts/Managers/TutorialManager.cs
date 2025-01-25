using System;
using UnityEngine;

namespace ggj_2025
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private GMChannel gmChannel;

        private void Awake()
        {
            if (gmChannel is null)
            {
                throw new System.Exception("GM Channel not assigned");
            }
        }
        
        public void StartGame()
        {
            gmChannel.GameStart();
        }
    }
}
