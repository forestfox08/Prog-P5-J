using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public List<GameObject> enemies = new List<GameObject>(); 

    public float spawnInterval = 1f; 
    public int spawnPerInterval = 3;  

    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnMultipleEnemies(100);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClearAllEnemies();
        }
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            SpawnMultipleEnemies(spawnPerInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnMultipleEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemies.Add(newEnemy);
        }
    }

    void ClearAllEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }
}
