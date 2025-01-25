using UnityEngine;

namespace ggj_2025
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIChannel uiChannel;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            if (uiChannel is null)
            {
                throw new System.Exception("UI Channel not assigned");
            }
            uiChannel.OnHealthChanged += HealthChanged;
        }
        private void HealthChanged(float currentHealth, float maxHealth)
        {
            // Update UI
        }
    }
}
