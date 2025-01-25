using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ggj_2025
{
    [RequireComponent(typeof(PlayerMovementController), typeof(PlayerCrosshairController), typeof(PlayerShootingController))]
    public class PlayerController : MonoBehaviour
    {
        // Properties ==============================================
        public float MaxHealth { get; private set; } = 100f;
        public float CurrentHealth { get; private set; }
        private float _shield = 0;
        public int PlayerIndex = 0;
        public float SelfDamageBigEmoEnobyVampireHarryIhearthMCR = 0.1f;

        private float _powerCooldownSec = 5f;
        
        private readonly Vector2[] _directions =
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right,
            new Vector2(1, 1).normalized,
            new Vector2(-1, 1).normalized,
            new Vector2(1, -1).normalized,
            new Vector2(-1, -1).normalized,
        };
        
        // Channels =================================================
        [SerializeField] private UIChannel uiChannel;
        
        // Events and Delegates =====================================
        public delegate void ToggleShield(bool shieldOn);
        public event ToggleShield OnToggleShield;
        
        // Controllers ==============================================
        private PlayerMovementController _movementController;
        private PlayerCrosshairController _crosshairController;
        private PlayerShootingController _shootingController;
        [SerializeField] private InputSystem inputSystem;
        private float _powerCooldownTs;

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
            _shootingController = GetComponent<PlayerShootingController>();
        }

        private void FixedUpdate()
        {
            _movementController.Move(inputSystem);
            TakeDamage(SelfDamageBigEmoEnobyVampireHarryIhearthMCR);
        }

        //Use Update for non-physics based functions
        void Update()
        {
            var aim = _crosshairController.UpdateCrosshair(inputSystem);
            if (inputSystem.GetFire())
            {
                _shootingController.TryShoot(aim);
            }
            
            if (inputSystem.GetSpecial())
            {
                TryUsePower();
            }
        }

        private void CheckShield()
        {
           OnToggleShield?.Invoke(_shield > 0);
        }
        
        
        public void TakeDamage(float damage)
        {
            if (_shield > 0)
            {
                _shield -= damage;
                if (_shield < 0)
                {
                    CurrentHealth += _shield;
                    _shield = 0;
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
            _shield += shieldAmount;
            CheckShield();
        }
        
        public void AddMaxHealth(float healthAmount)
        {
            MaxHealth += healthAmount;
            OnHealthChanged();
        }
        
        private void OnHealthChanged()
        {
            uiChannel.HealthChanged(CurrentHealth, MaxHealth, PlayerIndex);
        }

        private void TryUsePower()
        {
            if (Time.time < _powerCooldownTs) return;
            _powerCooldownTs = Time.time + _powerCooldownSec;
            _shootingController.ShootMultiple(_directions); 
        }





        
    }
}