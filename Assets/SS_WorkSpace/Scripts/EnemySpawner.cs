using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;  // 스테이지 이동 경로
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    
    [SerializeField]
    private Wave[] waves;
    private Wave currentWave;
    private int currentWaveIndex = -1;
    private int spawnEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
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
                GameObject clone = MonsterObjectPoolManager.Instance.GetMonster(currentWave.key).gameObject;
                EnemyMove enemyMove = clone.GetComponent<EnemyMove>();
                
                enemyMove.Setup(wayPoints);

                SpawnEnemyHPSlider(clone);

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
    
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab, canvasTransform, true);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<MonsterController>());
    }
}
