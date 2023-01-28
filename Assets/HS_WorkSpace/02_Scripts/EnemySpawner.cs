using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer = 1.0f;
    public Vector2 spawnPos;

    Coroutine lastCoroutine;
    
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
            GameObject obj = Instantiate(enemy, spawnPos, Quaternion.identity) as GameObject;
            GameManager.Instance.monsterList.Add(obj, false);
            ++GameManager.Instance.monsterCount;
            yield return delay;
        }
    }
}