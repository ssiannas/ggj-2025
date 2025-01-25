using UnityEngine;

namespace ggj_2025
{
    [CreateAssetMenu(fileName = "KeyboardInput", menuName = "Scriptable Objects/KeyboardInput")]
    public class KeyboardInput : InputSystem
    {
        public override Vector2 GetMovement()
        {
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return input.normalized;
        }

        public override Vector2 GetAim(Transform sourceTransform, Camera mainCamera)
        {
            if (mainCamera is null)
            {
                return Vector2.zero;
            }

            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return ((Vector2)sourceTransform.transform.position - mousePos).normalized;
        }

        public override bool GetFire()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public override bool GetSpecial()
        {
            return Input.GetKeyDown(KeyCode.E);
        }
    }
}