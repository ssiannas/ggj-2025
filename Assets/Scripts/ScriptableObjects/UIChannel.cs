using System;
using UnityEngine;
using UnityEngine.Events;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "UIChannel", menuName = "Scriptable Objects/UIChannel")]
    public class UIChannel : ScriptableObject
    {
        public UnityAction<float, float, int> OnHealthChanged;
        
        public void HealthChanged(float currentHealth, float maxHealth, int playerIndex)
        {
            if (OnHealthChanged == null)
            {
               throw new Exception("No UI Manager Assigned");
            }
            OnHealthChanged?.Invoke(currentHealth, maxHealth, playerIndex);
        }
    }
}
