using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;

    public Vector2 spawnAreaMin = new Vector2(-8f, -4f);
    public Vector2 spawnAreaMax = new Vector2(8f, 4f);

    public LayerMask obstacleLayer; // ← сюда перетащишь слой "Wall" или "Obstacle"
    public float checkRadius = 0.5f; // радиус круга для проверки

    public int maxAttempts = 10; // максимум попыток найти подходящее место

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            TrySpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void TrySpawnEnemy()
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPos = new Vector2(x, y);

            // Проверка на наличие препятствий (стены, здания и т.д.)
            Collider2D hit = Physics2D.OverlapCircle(spawnPos, checkRadius, obstacleLayer);

            if (hit == null)
            {
                // Место свободно — спавним
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("Не удалось найти свободное место для врага.");
    }
}
