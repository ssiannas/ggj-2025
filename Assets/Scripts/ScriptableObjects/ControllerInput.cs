using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "ControllerInput", menuName = "Scriptable Objects/ControllerInput")]
    public class ControllerInput : InputSystem
    {
        // For multiplayer, we might need to store device ID in the player information
        public override Vector2 GetAim(Transform sourceTransform, Camera mainCamera)
        {
           var gamepad = Gamepad.current;
           var input = new Vector2(gamepad.rightStick.x.ReadValue(), gamepad.rightStick.y.ReadValue());
           return input.normalized;
        }

        public override Vector2 GetMovement()
        {
           var gamepad = Gamepad.current;
           var input = new Vector2(gamepad.leftStick.x.ReadValue(), gamepad.leftStick.y.ReadValue());
           return input.normalized;
        }

        public override bool GetSpecial()
        {
            return Gamepad.current[GamepadButton.North].isPressed;
        }

        public override bool GetFire()
        {
            // Use right button (circle or B) to fire
            return Gamepad.current[GamepadButton.East].isPressed;
        }
    }
}