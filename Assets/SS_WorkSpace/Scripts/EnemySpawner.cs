using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] wayPoints;  // 스테이지 이동 경로

    public Wave[] waves;
    Wave currWave;
    int currWaveIndex = -1;
    int spawnEnemyCount = 0;

    Coroutine currCoroutine;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitUntil(() => GameManager.Instance.gameStart);
        while (GameManager.Instance.currWave < waves.Length)
        {
            GameManager.Instance.currWave++;
            GameManager.Instance.SetText();
            currWaveIndex++;
            currWave = waves[currWaveIndex];
            spawnEnemyCount = 0;
            if (currCoroutine != null)
            {
                StopCoroutine(currCoroutine);
            }
            StartStageTimer();
            while (spawnEnemyCount < MonsterObjectPoolManager.Instance.poolObjectDataList[currWaveIndex].maxObjectCount)
            {
                var monster = MonsterObjectPoolManager.Instance.GetMonster(currWave.key).gameObject;
                GameManager.Instance.monsterList.Add(monster, false);
                var enemyMove = monster.GetComponent<EnemyMove>();
                
                enemyMove.Setup(wayPoints);

                BindMonsterHpSlider(monster);

                spawnEnemyCount++;
                ++GameManager.Instance.currMonsterCount;
                GameManager.Instance.SetText();
                if (GameManager.Instance.currMonsterCount >= GameManager.Instance.monsterCountLimit)
                {
                    GameManager.Instance.LoadGameOverScene();
                    StopAllCoroutines();
                }

                if (currWave.enemyGrade == EnemyGrade.Low)
                {
                    yield return new WaitForSeconds(currWave.spawnTime);
                }
                else if (currWave.enemyGrade == EnemyGrade.Low && spawnEnemyCount == currWave.maxEnemyCount)
                {
                    yield return new WaitForSeconds(10f);
                }
                else if (currWave.enemyGrade == EnemyGrade.Boss)
                {
                    yield return new WaitForSeconds(90f);
                }
            }
        }
    }

    void StartStageTimer()
    {
        if (currWave.enemyGrade == EnemyGrade.Low)
        {
            currCoroutine = StartCoroutine(GameManager.Instance.StageTimer(currWave.spawnTime * currWave.maxEnemyCount + 10.0f));
        }
        else if (currWave.enemyGrade == EnemyGrade.Boss)
        {
            currCoroutine = StartCoroutine(GameManager.Instance.StageTimer(90.0f));
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
