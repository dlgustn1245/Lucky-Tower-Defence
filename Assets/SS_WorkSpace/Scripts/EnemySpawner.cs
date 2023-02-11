using System.Collections;
using System.Collections.Generic;
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
    private int waveCount = 0;
    private int currentWaveIndex = -1;
    private int spawnEnemyCount = 0;

    void Awake()
    {
    }

    void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        while (waveCount < waves.Length)
        {
            waveCount++;
            currentWaveIndex++;
            currentWave = waves[currentWaveIndex];
            spawnEnemyCount = 0;
            while (spawnEnemyCount < currentWave.maxEnemyCount)
            {
                GameObject clone = Instantiate(currentWave.enemyPrefab);
                EnemyMove enemyMove = clone.GetComponent<EnemyMove>();
                
                enemyMove.Setup(wayPoints);

                SpawnEnemyHPSlider(clone);

                spawnEnemyCount++;
                ++GameManager.Instance.currMonsterCount;

                if(currentWave.enemyGrade == EnemyGrade.Low)
                    yield return new WaitForSeconds(currentWave.spawnTime);
                else if(currentWave.enemyGrade == EnemyGrade.Low && spawnEnemyCount == currentWave.maxEnemyCount)
                    yield return new WaitForSecondsRealtime(10f);
                else if(currentWave.enemyGrade == EnemyGrade.Boss)
                    yield return new WaitForSecondsRealtime(90f);
            }
        }
    }


    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<MonsterController>());
    }
}
