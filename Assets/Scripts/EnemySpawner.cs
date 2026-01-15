using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 17.9f;
    private float spawnPosZ = 15.5f;
    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;
    
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Randomly spawn enemies
    private void SpawnRandomEnemy()
    {
        if (GameManager.isStarted) { 
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.64f, spawnPosZ);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
