using UnityEngine;
using UnityEngine.UI;

namespace ggj_2025
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] private Slider bar;
        public void SetHealth(float currentHealth, float maxHealth)
        {
            bar.maxValue = maxHealth;
            bar.value = currentHealth;
        }
    }
}
