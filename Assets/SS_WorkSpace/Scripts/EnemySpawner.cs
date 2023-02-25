using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;  // 스테이지 이동 경로
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    public Transform canvasTransform;
    
    [SerializeField]
    private Wave[] waves;
    private Wave currentWave;
    private int currentWaveIndex = -1;
    private int spawnEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3.0f);
        while (GameManager.Instance.currWave < waves.Length)
        {
            GameManager.Instance.currWave++;
            GameManager.Instance.SetText();
            currentWaveIndex++;
            currentWave = waves[currentWaveIndex];
            spawnEnemyCount = 0;
            while (spawnEnemyCount < MonsterObjectPoolManager.Instance.poolObjectDataList[currentWaveIndex].maxObjectCount)
            {
                var monster = MonsterObjectPoolManager.Instance.GetMonster(currentWave.key).gameObject;
                GameManager.Instance.monsterList.Add(monster, false);
                var enemyMove = monster.GetComponent<EnemyMove>();
                
                enemyMove.Setup(wayPoints);

                BindMonsterHpSlider(monster);

                spawnEnemyCount++;
                ++GameManager.Instance.currMonsterCount;
                GameManager.Instance.SetText();
                if (GameManager.Instance.currMonsterCount >= GameManager.Instance.monsterCountLimit)
                {
                    GameManager.Instance.gameOver = true;
                    StopAllCoroutines();
                }

                if (currentWave.enemyGrade == EnemyGrade.Low)
                {
                    yield return new WaitForSeconds(currentWave.spawnTime);
                }
                else if (currentWave.enemyGrade == EnemyGrade.Low && spawnEnemyCount == currentWave.maxEnemyCount)
                {
                    yield return new WaitForSeconds(10f);
                }
                else if (currentWave.enemyGrade == EnemyGrade.Boss)
                {
                    yield return new WaitForSeconds(90f);
                }
            }
        }
    }
    
    void BindMonsterHpSlider(GameObject enemy)
    {
        var hpBarClone = MonsterObjectPoolManager.Instance.GetHpBar();
        hpBarClone.transform.localScale = Vector3.one;
        hpBarClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        hpBarClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<MonsterController>());
        MonsterObjectPoolManager.Instance.monsterHpDic.Add(enemy.GetComponent<MonsterController>(), hpBarClone);
    }
}
