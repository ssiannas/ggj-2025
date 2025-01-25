using UnityEngine;

[CreateAssetMenu(fileName = "KeyboardInput", menuName = "Scriptable Objects/KeyboardInput")]
public class KeyboardInput : InputSystem
{
    // Returns the normalized unit vector for movement
    public override Vector2 getMovement()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return input.normalized;
    }

    public override Vector2 getAim(GameObject sourceTransform)
    {
        // Return normalized vector towards mouse cursor
        var camera = Camera.main;
        if (camera == null)
        {
            Debug.LogError("No camera found in scene");
            return Vector2.zero;
        }
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        return ((Vector2)sourceTransform.transform.position - mousePos).normalized;
    }
}
