using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    // Set the movement direction and speed
    public void SetMovement(Vector2 moveDirection, float moveSpeed)
    {
        direction = moveDirection.normalized; // Normalize direction to ensure consistent movement
        speed = moveSpeed;
    }

    void Update()
    {
        // Move the object in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }
}