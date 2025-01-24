using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5.0f;
    
    // Update is called once per frame
    private void Update()
    {
        // Get values from unity input systwm
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = input.normalized;
        input *= speed * Time.deltaTime;
        // move left - right by horizontal input and up, down by vertical input (normalize for when you press two at the same time)
        
        transform.Translate(new Vector3(input.x, input.y, 0));
    }
}
