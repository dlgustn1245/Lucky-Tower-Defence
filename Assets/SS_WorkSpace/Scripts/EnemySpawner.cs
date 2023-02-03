using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyGrade BossGrade = EnemyGrade.Boss; // Boss ��� ������ ����
    public List<Enemy> Enemies = new List<Enemy>(); // EnemyŬ������ ���
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
    private float spawnTime;        // �� ���� �ֱ�
    [SerializeField]
    private Transform[] wayPoints;  // �������� �̵� ���
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;

    //�ʿ� �����ϴ� ��� ���� ����
    private List<EnemyMove> enemyList;
    private List<EnemyMove> EnemyList => enemyList;

    void Awake()
    {
        // �� ����Ʈ �޸� �Ҵ�
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
            // �����ϰ��
            if (Enemies[enemyIndex].enemyGrade == BossGrade)
            {
                //���� ��ȯ
                GameObject clonBoss = Instantiate(Enemies[enemyIndex].enemyPrefabs);
                EnemyMove bossMove = clonBoss.GetComponent<EnemyMove>();
                bossMove.Setup(this, wayPoints);
                enemyList.Add(bossMove);
                SpawnEnemyHPSlider(clonBoss);
                bossCount += 1; //���� ī��Ʈ 1 ����
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
        // ����Ʈ���� ����ϴ� �� ���� ����
        enemyList.Remove(enemyMove);
        // �� ������Ʈ ����
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
