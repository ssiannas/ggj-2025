using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "KeyboardInput", menuName = "Scriptable Objects/KeyboardInput")]
    public class KeyboardInput : InputSystem
    {
        public override Vector2 GetMovement()
        {
            var input = new Vector2(0,0);
            if (Input.GetKey(KeyCode.W))
            {
                input.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                input.y -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                input.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                input.x += 1;
            }
            return input.normalized;
        }

        public override Vector2 GetAim(Transform sourceTransform, Camera mainCamera)
        {
            if (mainCamera is null)
            {
                return Vector2.zero;
            }

            var mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
            return ((Vector2)mousePos - (Vector2)sourceTransform.transform.position).normalized;
        }

        public override bool GetFire()
        {
            return Input.GetKey(KeyCode.Space);
        }

        public override bool GetSpecial()
        {
            return Input.GetKeyDown(KeyCode.E);
        }
        
        public override void StartRumble(float durationSec = 0.5f)
        {
            // No rumble for keyboard
        }
        
        public override void StopRumble()
        {
            // No rumble for keyboard
        }
    }
}