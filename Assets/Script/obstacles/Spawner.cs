using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects to Spawn")]
    public GameObject[] objectsToSpawn;

    [Header("Spawn Timing")]
    public float spawnInterval = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;
        }
    }

    void SpawnRandomObject()
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("Spawner: No objects assigned.");
            return;
        }

        // Pick a random object
        int randomObjIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject prefab = objectsToSpawn[randomObjIndex];

        // Spawn at the spawner's own position
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
