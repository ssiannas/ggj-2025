using UnityEngine;

namespace ggj_2025
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIChannel uiChannel;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private HealthBarController[] _healthBarControllers = new HealthBarController[2];
        private void Awake()
        {
            if (uiChannel is null)
            {
                throw new System.Exception("UI Channel not assigned");
            }
            //_healthBarControllers[0] = GetComponent<HealthBarController>();
            uiChannel.OnHealthChanged += HealthChanged;
        }
        private void HealthChanged(float currentHealth, float maxHealth, int playerIndex)
        {
            // Update UI
            _healthBarControllers[playerIndex].SetHealth(currentHealth, maxHealth);
        }
    }
}
