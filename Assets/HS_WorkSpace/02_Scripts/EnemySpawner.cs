using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer = 1.0f;
    public Vector2 spawnPos;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    void Update()
    {
        if (GameManager.Instance.gameOver || GameManager.Instance.gameClear)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnEnemy()
    {
        var delay = new WaitForSeconds(spawnTimer);
        while (true)
        {
            print("Spawn");
            GameObject obj = Instantiate(enemy, spawnPos, Quaternion.identity) as GameObject;
            GameManager.Instance.monsterList.Add(obj, false);
            ++GameManager.Instance.currMonsterCount;
            GameManager.Instance.SetMonsterCountText();
            yield return delay;
        }
    }
}