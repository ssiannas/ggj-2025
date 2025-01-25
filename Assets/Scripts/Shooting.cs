using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Assign your bullet in the Inspector
    public GameObject prefab;

    // Optional: Set the position where prefabs will spawn
    public Vector2 spawnPosition = Vector2.zero;

    public Vector2 projDirection = Vector2.right; // Direction of bullets (e.g., forward)
    public float projSpeed = 5f; // Speed of bullets


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefab();
        }
    }


    void SpawnPrefab()
    {
        if (prefab != null)
        {
            // Calculate the new spawn position based on spawn count
            Vector2 position = spawnPosition;

            // Instantiate the prefab
            GameObject projectile = Instantiate(prefab, position, Quaternion.identity);


            // Add a script to make the prefab move
            BulletMovement moveScript = projectile.AddComponent<BulletMovement>();
            moveScript.SetMovement(projDirection, projSpeed);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned in the Inspector!");
        }
    }
}