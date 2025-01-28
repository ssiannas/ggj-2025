using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

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
        
        private Vector2 _aim = Vector2.up;

        public Vector2 Aim
        {
            get => _aim;
            set 
            {
                if (value != Vector2.zero) _aim = value;
                _crosshairController.UpdateCrosshair(_aim);
            }
        }

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
        [SerializeField] private AudioChannel audioChannel;
        
        // Events and Delegates =====================================
        public delegate void ToggleShield(bool shieldOn);
        public event ToggleShield OnToggleShield;
        
        // Controllers ==============================================
        private PlayerMovementController _movementController;
        private PlayerCrosshairController _crosshairController;
        private PlayerShootingController _shootingController;
        private PlayerAnimationController _animationController;
        private SpriteRenderer _spriteRenderer;
        private float _powerCooldownTs;

        private void Awake()
        {
           

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
            //TakeDamage(SelfDamageBigEmoEnobyVampireHarryIhearthMCR);
        }

        //Use Update for non-physics based functions
        void Update()
        { 
            _movementController.Move();
            _crosshairController.UpdateCrosshair(_aim);
            State = GetPlayerState(_aim);
            _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100) * -1;
        }

        private void CheckShield()
        {
           OnToggleShield?.Invoke(_shield > 0);
        }
        
        public void TryShoot()
        {
            _shootingController.TryShoot(_aim);
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
            
            Gamepad.current.SetMotorSpeeds(0.5f, 0.5f);
            StartCoroutine(StopRumbleAfter(0.2f));

            OnHealthChanged();
            if (CurrentHealth <= 0)
            {
                StartCoroutine(StopRumbleAfter(0.1f));
                audioChannel.PlayAudio("win_sfx");
                if (PlayerIndex == 1) {
                    SceneManager.LoadScene("WinnerP1");
                } else {
                    SceneManager.LoadScene("WinnerP2");
                }
            }
        }
        private IEnumerator StopRumbleAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Gamepad.current.SetMotorSpeeds(0, 0);
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

        public void TryUsePower()
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
                    audioChannel.PlayAudio("walk_sfx");
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
                    _animationController.StartIdle();
                    audioChannel.StopAudio("walk_sfx");
                   break;
               default:
                   throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
           }
        }
        private PlayerState GetPlayerState(Vector2 aim)
        {
            var startVec = new Vector2(-1,1).normalized;
            var angle = -Vector2.SignedAngle(startVec, aim);
            if (_movementController.Direction == Vector2.zero)
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
        
        
        // ----- INPUT SYSTEM CALLBACKS -----
        public void OnMove(CallbackContext context)
        {
        }
    }
}