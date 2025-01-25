using UnityEngine;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "KeyboardInput", menuName = "Scriptable Objects/KeyboardInput")]
    public class KeyboardInput : InputSystem
    {
        // Returns the normalized unit vector for movement
        public override Vector2 getMovement()
        {
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return input.normalized;
        }

        public override Vector2 getAim(Transform sourceTransform, Camera mainCamera)
        {
            // Return normalized vector towards mouse cursor
            if (mainCamera is null)
            {
                return Vector2.zero;
            }

            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return ((Vector2)sourceTransform.transform.position - mousePos).normalized;
        }

        public override bool getFire()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public override bool getSpecial()
        {
            return Input.GetKeyDown(KeyCode.E);
        }
    }
}