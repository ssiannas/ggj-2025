using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "ControllerInput", menuName = "Scriptable Objects/ControllerInput")]
    public class ControllerInput : InputSystem
    {
        private Vector2 _lastAim = Vector2.right;
        public int PlayerIndex = 0;
        private bool[] _isRumbling = {
            false, false
        };
        // For multiplayer, we might need to store device ID in the player information
        public override Vector2 GetAim(Transform sourceTransform, Camera mainCamera)
        {
            var gamepad = Gamepad.all[PlayerIndex];
            var input = new Vector2(gamepad.rightStick.x.ReadValue(), gamepad.rightStick.y.ReadValue());
            if (input.magnitude > 0.1f)
            {
                _lastAim = input.normalized;
            }

            return _lastAim;
        }

        public override Vector2 GetMovement()
        {
            var gamepad = Gamepad.all[PlayerIndex];
            var input = new Vector2(gamepad.leftStick.x.ReadValue(), gamepad.leftStick.y.ReadValue());
            return input.normalized;
        }

        public override bool GetSpecial()
        {
            return Gamepad.all[PlayerIndex][GamepadButton.LeftTrigger].isPressed;
        }

        public override bool GetFire()
        {
            // Use right button (circle or B) to fire
            return Gamepad.all[PlayerIndex][GamepadButton.RightTrigger].isPressed;
        }

        public override void StartRumble(float durationSec = 0.5f)
        {
            if (_isRumbling[PlayerIndex]) return;
            _isRumbling[PlayerIndex] = true;
            var gamepad = Gamepad.all[PlayerIndex];
            gamepad.SetMotorSpeeds(0.5f, 0.5f);
        }

        public override void StopRumble()
        {
            var gamepad = Gamepad.all[PlayerIndex];
            _isRumbling[PlayerIndex] = false;
            gamepad.SetMotorSpeeds(0, 0);
        }
    }

}