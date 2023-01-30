using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyGrade BossGrade = EnemyGrade.Boss;
    public List<Enemy> Enemys = new List<Enemy>();
    private int maxBoss = 1;
    private int bossCount = 0;
    [SerializeField]
    private int maxEnemy = 0;
    [SerializeField]
    private int enemyCount = 0;
    [SerializeField]
    private int enemyIndex = 0;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;

    void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (Enemys[enemyIndex].enemyGrade == BossGrade)
            {
                GameObject clonBoss = Instantiate(Enemys[enemyIndex].enemyPrefabs);
                EnemyMove BossMove = clonBoss.GetComponent<EnemyMove>();
                BossMove.Setup(wayPoints);
                bossCount = 1;
            }
            else
            {
                enemyCount++;
                GameObject clon = Instantiate(Enemys[enemyIndex].enemyPrefabs);
                EnemyMove enemyMove = clon.GetComponent<EnemyMove>();
                enemyMove.Setup(wayPoints);
            }

            if(enemyCount == maxEnemy || bossCount==1)
            {
                if (enemyIndex == Enemys.Count || bossCount == maxBoss)
                {
                    StopCoroutine("SpawnEnemy");
                }
                enemyIndex += 1;
                enemyCount = 0;
                
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
