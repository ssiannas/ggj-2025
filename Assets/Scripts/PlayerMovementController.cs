using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5.0f;
    
    // Update is called once per frame
    private void Update()
    {
        // Get values from unity input systwm
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        // move left - right by horizontal input and up, down by vertical input (normalize for when you press two at the same time)
        var factorX = speed * input.x * Time.deltaTime;
        var factorY = speed * input.y * Time.deltaTime;
        transform.Translate(Vector3.up * factorY, Space.Self);
        transform.Translate(Vector3.right * factorX, Space.Self);
    }
}
