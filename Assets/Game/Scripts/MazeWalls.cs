using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWalls : MonoBehaviour
{
    //private Vector3 size = new Vector3 (10, 10, 10);

    public GameObject[] spawnPrefabs;
    public float spawnRadius = 1f;
    public int spawnAmount = 1;
    public int currentSpawn;
    public int maxSpawn = 1;
    public int spawnInterval = 1;
    private bool hasSpawned = false;

    public int[] randomRotation = null;

    // Use this for initialization
    void Start()
    {
        currentSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSpawned == false && currentSpawn < maxSpawn)
        {

            StartCoroutine(SpawnNow());
            currentSpawn++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnMazeWalls()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Spawned new GameObject
            int randomIndex = Random.Range(0, spawnPrefabs.Length);

            // Store randomly selected prefab
            GameObject randomPrefab = spawnPrefabs[randomIndex];

            // Spawned new GameObject
            GameObject clone = Instantiate(randomPrefab);

            // Calculate random position within sphere
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius; // calculate random position

            // Lock the Y
            randomPos.y = 2.5f;

            // Set spawned object's position
            clone.transform.position = randomPos;

            int randomRotIndex = Random.Range(0,randomRotation.Length);

            clone.transform.rotation = Quaternion.Euler(0, randomRotation[randomRotIndex], 0);
        }
    }

    IEnumerator SpawnNow()
    {
        // run whatever is here first
        hasSpawned = true;

        // Spawn the Enemy
        SpawnMazeWalls();

        yield return new WaitForSeconds(spawnInterval); // wait a few seconds

        // run whatever is here last
        hasSpawned = false;
    }
}
