using UnityEngine;

namespace ggj_2025
{
    [RequireComponent(typeof(HealthBarController))]
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIChannel uiChannel;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private HealthBarController _healthBarController; 
        private void Awake()
        {
            if (uiChannel is null)
            {
                throw new System.Exception("UI Channel not assigned");
            }
            _healthBarController = GetComponent<HealthBarController>();
            uiChannel.OnHealthChanged += HealthChanged;
        }
        private void HealthChanged(float currentHealth, float maxHealth)
        {
            // Update UI
            _healthBarController.SetHealth(currentHealth, maxHealth);
        }
    }
}
