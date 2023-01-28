using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer = 1.0f;
    public Vector2 spawnPos;

    private Coroutine lastCoroutine;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        var delay = new WaitForSeconds(spawnTimer);
        while (true)
        {
            print("Spawn");
            Instantiate(enemy, spawnPos, Quaternion.identity);
            ++GameManager.Instance.monsterCount;
            yield return delay;
        }
    }
}
