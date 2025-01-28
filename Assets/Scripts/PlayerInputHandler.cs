using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace ggj_2025
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private readonly GameObject[] _players = new GameObject[2];
        private PlayerController _playerController;
        private PlayerMovementController _movementController;
        private PlayerCrosshairController _crosshairController;
        private GameObject ThisPlayer => _players[_playerInput.playerIndex];

        void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _players[0] = GameObject.FindWithTag("P1");
            _players[1] = GameObject.FindWithTag("P2");
            var thisPlayer = _players[_playerInput.playerIndex];
            _playerController = thisPlayer.GetComponent<PlayerController>();
            _movementController = thisPlayer.GetComponent<PlayerMovementController>();
            _crosshairController = thisPlayer.GetComponent<PlayerCrosshairController>();
            // Sus logic, need to refactor for multiplayer?
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void OnMove(CallbackContext ctx)
        {
            if (ctx.canceled)
            {
                _movementController.Direction = Vector2.zero;
                return;
            }
            var input = ctx.ReadValue<Vector2>();
            _movementController.Direction = input.normalized;
        }

        public void OnFire(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _playerController.TryShoot();
            }
        }
        
        public void OnPower(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _playerController.TryUsePower();
            }
        }

        public void OnAim(CallbackContext ctx)
        {
            
            var value = ctx.ReadValueAsObject();
            if (value is not Vector2) return;
            var input = (Vector2) value;
            if (input  != Vector2.zero)
            {
                _playerController.Aim = input.normalized;
            }
        }

        public void OnAimMouse(CallbackContext ctx)
        {
            if (!ctx.performed) return;
            var value = ctx.ReadValueAsObject();
            var mainCamera = Camera.main;
            if (value is not Vector2 input) return;
            if (input == Vector2.zero) return;
            if (mainCamera is null) return;
            var screenPos = new Vector3(input.x, input.y, 10);
            var distance  = ThisPlayer.transform.position - mainCamera.ScreenToWorldPoint(screenPos);
            _playerController.Aim = -1 * distance.normalized;
        }
    }
}
