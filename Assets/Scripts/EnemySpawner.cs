using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemyNormalPrefab;
    public GameObject enemyQuickPrefab;
    public GameObject enemyStrongPrefab;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;

    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints == null || spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefabToSpawn = PickEnemyPrefab();

        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }

    private GameObject PickEnemyPrefab()
    {
        // 0-79 = normale (80%)
        // 80-89 = quick (10%)
        // 90-99 = strong (10%)
        int roll = Random.Range(0, 100);

        if (roll < 80) return enemyNormalPrefab;
        if (roll < 90) return enemyQuickPrefab;
        return enemyStrongPrefab;
    }
}
