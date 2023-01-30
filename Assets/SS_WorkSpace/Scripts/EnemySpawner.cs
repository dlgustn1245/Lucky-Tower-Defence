using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyGrade BossGrade = EnemyGrade.Boss; // Boss ��� ������ ����
    public List<Enemy> Enemys = new List<Enemy>(); // EnemyŬ������ ���
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

    //�ʿ� �����ϴ� ��� ���� ����
    private List<EnemyMove> enemyList;
    private List<EnemyMove> EnemyList => enemyList;

    void Awake()
    {
        // �� ����Ʈ �޸� �Ҵ�
        enemyList = new List<EnemyMove>();
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // �����ϰ��
            if (Enemys[enemyIndex].enemyGrade == BossGrade)
            {
                //���� ��ȯ
                GameObject clonBoss = Instantiate(Enemys[enemyIndex].enemyPrefabs);
                EnemyMove bossMove = clonBoss.GetComponent<EnemyMove>();
                bossMove.Setup(this, wayPoints);
                enemyList.Add(bossMove);
                bossCount += 1; //���� ī��Ʈ 1 ����
            }
            else
            {
                enemyCount++;
                GameObject clon = Instantiate(Enemys[enemyIndex].enemyPrefabs);
                EnemyMove enemyMove = clon.GetComponent<EnemyMove>();
                enemyMove.Setup(this, wayPoints);
                enemyList.Add(enemyMove);
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

    public void DestroyEnemy(EnemyMove enemyMove)
    {
        // ����Ʈ���� ����ϴ� �� ���� ����
        enemyList.Remove(enemyMove);
        // �� ������Ʈ ����
        Destroy(enemyMove.gameObject);
    }
}
