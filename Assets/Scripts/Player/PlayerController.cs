using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ggj_2025
{
    [RequireComponent(typeof(PlayerMovementController), typeof(PlayerCrosshairController))]
    public class PlayerController : MonoBehaviour
    {
        // Properties ==============================================
        public float MaxHealth { get; private set; } = 100f;
        public float CurrentHealth { get; private set; }
        private float shield = 0f;
        
        // Channels =================================================
        [SerializeField] private UIChannel uiChannel;
        
        // Events and Delegates =====================================
        public delegate void ToggleShield(bool shieldOn);
        public event ToggleShield OnToggleShield;
        
        // Controllers ==============================================
        private PlayerMovementController _movementController;
        private PlayerCrosshairController _crosshairController;
        [SerializeField] private InputSystem inputSystem;

        private void Awake()
        {
            if (inputSystem is null)
            {
                throw new Exception("Input system not assigned");
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            CurrentHealth = MaxHealth;
            _movementController = GetComponent<PlayerMovementController>();
            _crosshairController = GetComponent<PlayerCrosshairController>();
        }

        private void FixedUpdate()
        {
            _movementController.Move(inputSystem);
            var aim = _crosshairController.UpdateCrosshair(inputSystem);
            if (inputSystem.GetFire())
            {
                // Shoot(aim)
            }
            if (inputSystem.GetSpecial())
            {
                // Special
            }
            TakeDamage(0.1f);
        }

        private void CheckShield()
        {
           OnToggleShield?.Invoke(shield > 0);
        }
        
        
        public void TakeDamage(float damage)
        {
            if (shield > 0)
            {
                shield -= damage;
                if (shield < 0)
                {
                    CurrentHealth += shield;
                    shield = 0;
                    CheckShield();
                }
            }
            else
            {
                CurrentHealth -= damage;
            }

            OnHealthChanged();
            if (CurrentHealth <= 0)
            {
                //Die();
                Destroy(gameObject);
            }
        }
        
        public void Heal(float healAmount)
        {
            CurrentHealth += healAmount;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }

            OnHealthChanged();
        }
        
        public void AddShield(float shieldAmount)
        {
            shield += shieldAmount;
            CheckShield();
        }
        
        public void AddMaxHealth(float healthAmount)
        {
            MaxHealth += healthAmount;
            OnHealthChanged();
        }
        
        private void OnHealthChanged()
        {
            uiChannel.HealthChanged(CurrentHealth, MaxHealth);
        }
    }
}