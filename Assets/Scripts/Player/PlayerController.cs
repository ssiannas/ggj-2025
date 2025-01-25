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
        private float bulletSpeed = 5f;
        public GameObject projectilePrefab;
        private float _firerate = 1f;
        private float _cooldownTimestamp;
        private float _fireCooldown;
        [SerializeField] public float Firerate
        {
            get { return _firerate; }
            private set
            {
                _firerate = value;
                _fireCooldown = 1 / value;
            }
        }
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
            Firerate = _firerate;
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
            if (inputSystem.GetSpecial())
            {
                // Special
            }
            //TakeDamage(0.1f);
        }

        //Use Update for non-physics based functions
        void Update()
        {
            _movementController.Move(inputSystem);
            var aim = _crosshairController.UpdateCrosshair(inputSystem);
            if (inputSystem.GetFire())
            {
                TryShoot(aim);
            }
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


        private void Shoot(Vector2 direction)
        {
            if (projectilePrefab != null)
            {
                // Calculate the new spawn position
                Vector2 position = transform.transform.position;

                // Instantiate the prefab
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);


                // Add a script to make the prefab move
                BulletMovement moveScript = projectile.AddComponent<BulletMovement>();
                moveScript.SetMovement(direction, bulletSpeed);
            }
            else
            {
                Debug.LogWarning("Prefab is not assigned in the Inspector!");
            }
        }



        private void TryShoot(Vector2 direction)
        {
            if (Time.time < _cooldownTimestamp) return;
            _cooldownTimestamp = Time.time + _fireCooldown;
            // Shoot!
            Shoot(direction);
        }

        
    }
}