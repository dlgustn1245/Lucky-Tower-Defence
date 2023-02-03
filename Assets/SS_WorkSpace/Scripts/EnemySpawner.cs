using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyGrade BossGrade = EnemyGrade.Boss; // Boss 등급 열거형 변수
    public List<Enemy> Enemies = new List<Enemy>(); // Enemy클래스를 사용
    [SerializeField]
    private int maxBoss = 1; 
    private int bossCount = 0;
    [SerializeField]
    private int maxEnemy = 0;
    [SerializeField]
    private int enemyCount = 0;
    [SerializeField]
    private int enemyIndex = 0;
    [SerializeField]
    private float spawnTime;        // 적 생성 주기
    [SerializeField]
    private Transform[] wayPoints;  // 스테이지 이동 경로
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;

    //맵에 존재하는 모든 적의 정보
    private List<EnemyMove> enemyList;
    private List<EnemyMove> EnemyList => enemyList;

    void Awake()
    {
        // 적 리스트 메모리 할당
        enemyList = new List<EnemyMove>();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (enemyCount == maxEnemy || bossCount == 1)
            {
                if (enemyIndex == Enemies.Count || bossCount == maxBoss)
                {
                    StopCoroutine("SpawnEnemy");
                }
                enemyIndex += 1;
                enemyCount = 0;
            }
            // 보스일경우
            if (Enemies[enemyIndex].enemyGrade == BossGrade)
            {
                //보스 소환
                GameObject clonBoss = Instantiate(Enemies[enemyIndex].enemyPrefabs);
                EnemyMove bossMove = clonBoss.GetComponent<EnemyMove>();
                bossMove.Setup(this, wayPoints);
                enemyList.Add(bossMove);
                SpawnEnemyHPSlider(clonBoss);
                bossCount += 1; //보스 카운트 1 증가
            }
            else
            {
                enemyCount++;
                GameObject clon = Instantiate(Enemies[enemyIndex].enemyPrefabs);
                EnemyMove enemyMove = clon.GetComponent<EnemyMove>();
                enemyMove.Setup(this, wayPoints);
                enemyList.Add(enemyMove);
                SpawnEnemyHPSlider(clon);
            }
            
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void DestroyEnemy(EnemyMove enemyMove)
    {
        // 리스트에서 사망하는 적 정보 삭제
        enemyList.Remove(enemyMove);
        // 적 오브젝트 삭제
        Destroy(enemyMove.gameObject);
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
