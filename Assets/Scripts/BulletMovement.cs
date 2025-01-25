using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float damage = 10f;
    public float size = 1f;

    // Set the movement direction and speed
    public void SetMovement(Vector2 moveDirection, float moveSpeed)
    {
        direction = moveDirection.normalized; // Normalize direction to ensure consistent movement
        speed = moveSpeed;
    }

    private void Start()
    {
        transform.localScale = new Vector3 (size, size, size);
    }
    void Update()
    {
        // Move the object in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
        //TO DO: RIGID BOODY
    }
}