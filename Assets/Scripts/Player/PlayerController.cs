using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ggj_2025
{
    [RequireComponent(typeof(PlayerMovementController))]
    public class PlayerController : MonoBehaviour
    {
        public float MaxHealth { get; private set; } = 100f;

        public float CurrentHealth { get; private set; }
        
        public delegate void ToggleShield(bool shieldOn);
        public event ToggleShield OnToggleShield;

        private float shield = 0f;
        
        // Controllers
        private PlayerMovementController _movementController;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            CurrentHealth = MaxHealth;
            _movementController = GetComponent<PlayerMovementController>();
        }

        private void Update()
        {
            _movementController.Move();
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
        }
        
        public void AddShield(float shieldAmount)
        {
            shield += shieldAmount;
            CheckShield();
        }
        
        public void AddMaxHealth(float healthAmount)
        {
            MaxHealth += healthAmount;
        }
    }
}