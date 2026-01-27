using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public GameObject[] enemyPrefabs;

    [SerializeField] private float spawnRangeX = 17.9f;
    [SerializeField] private float spawnPosZ = 15.5f;
    [SerializeField] private float spawnInterval = 2.0f;

    public int enemyMax;
    public static int enemyCount;

    private Coroutine spawnRoutine;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        enemyMax = 5;
    }

    // Called when a wave starts
    public void StartSpawning()
    {
        enemyCount = 0;

        if (spawnRoutine == null)
        {
            spawnRoutine = StartCoroutine(SpawnLoop());
        }
    }

    // Called when a wave ends
    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (enemyCount < enemyMax)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }

        // max reached so end the wave
        GameManager.Instance.TryEndWave();
    }

    // Method to spawn random enemies.
    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            0.64f,
            spawnPosZ
        );

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        enemyCount++;
    }
}
