using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace ggj_2025
{
    [RequireComponent(typeof(PlayerMovementController), typeof(PlayerCrosshairController),
        typeof(PlayerShootingController))]
    [RequireComponent(typeof(PlayerAnimationController))]
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

        // State management ========================================
        private PlayerState _state = PlayerState.IDLE;

        public PlayerState State
        {
            get => _state;
            private set
            {
                if (_state == value) return;
                StopOldState(_state);
                StartNewState(value);
                _state = value;
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
        private PlayerShootingController _shootingController;
        private PlayerAnimationController _animationController;
        private SpriteRenderer _spriteRenderer;
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
            _animationController = GetComponent<PlayerAnimationController>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            _movementController.Move(inputSystem);
            //TakeDamage(SelfDamageBigEmoEnobyVampireHarryIhearthMCR);
        }

        //Use Update for non-physics based functions
        void Update()
        {
            var aim = _crosshairController.UpdateCrosshair(inputSystem);
            State = GetPlayerState(aim);
            
            if (inputSystem.GetFire())
            {
                _shootingController.TryShoot(aim);
            }
            
            if (inputSystem.GetSpecial())
            {
                TryUsePower();
            }
            
            _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100) * -1;
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
            
            inputSystem.StartRumble();
            StartCoroutine(StopRumbleAfter(0.2f));

            OnHealthChanged();
            if (CurrentHealth <= 0)
            {
                //Die();
                Destroy(gameObject);
            }
        }
        private IEnumerator StopRumbleAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            inputSystem.StopRumble();
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

        private void StopOldState(PlayerState state)
        {
            switch(state) 
            {
                case PlayerState.WALK_UP:
                    _animationController.StopWalkUp();
                    break;
                case PlayerState.WALK_DOWN:
                    _animationController.StopWalkDown();
                    break;
                case PlayerState.WALK_LEFT:
                    _animationController.StopWalkLeft();
                    break;
                case PlayerState.WALK_RIGHT:
                    _animationController.StopWalkRight();
                    break;
                case PlayerState.IDLE:
                    _animationController.StopIdle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void StartNewState(PlayerState newState)
        {
           switch (newState) 
           {
               case PlayerState.WALK_UP:
                   _animationController.StartWalkUp();
                   break;
               case PlayerState.WALK_DOWN:
                     _animationController.StartWalkDown();
                   break;
               case PlayerState.WALK_LEFT:
                     _animationController.StartWalkLeft();
                   break;
               case PlayerState.WALK_RIGHT:
                        _animationController.StartWalkRight();
                   break;
               case PlayerState.IDLE:
                   break;
               default:
                   throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
           }
        }
        private PlayerState GetPlayerState(Vector2 aim)
        {
            var startVec = new Vector2(-1,1).normalized;
            var angle = -Vector2.SignedAngle(startVec, aim);
            Debug.Log(angle);
            if (!inputSystem.GetFire() && inputSystem.GetMovement() == Vector2.zero)
            {
                return PlayerState.IDLE;
            }

            return angle switch
            {
                > 0 and <= 90 => PlayerState.WALK_UP,
                > 90 and <= 180 => PlayerState.WALK_RIGHT,
                > -90 and <= 0 => PlayerState.WALK_LEFT,
                > -180 and <= -90 => PlayerState.WALK_DOWN,
                _ => PlayerState.IDLE
            };
        }
    }
}