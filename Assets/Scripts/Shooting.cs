using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Assign your bullet in the Inspector
    public GameObject prefab;

    // Optional: Set the position where prefabs will spawn
    public Vector3 spawnPosition = Vector3.zero;
    // Optional: Add an offset for each new prefab
    public Vector3 spawnOffset = new Vector3(1, 0, 0);
    private int spawnCount = 0;
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
            Vector3 position = spawnPosition + (spawnOffset * spawnCount);

            // Instantiate the prefab
            Instantiate(prefab, position, Quaternion.identity);

            // Increase the spawn count
            spawnCount++;
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned in the Inspector!");
        }
    }
}