using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private int wayPointCount;          // �̵� ��� ����
    private Transform[] wayPoints;      // �̵� ��� ����
    private int currentIndex = 0;       // ���� ��ǥ���� �ε���
    private Movement2D movement2D;
    private EnemySpawner enemySpawner;  // ���� ������ EnemySpawner���� �����ϱ� ����
    private bool flipFlag = false;


    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;

        // �� �̵� ��� WayPoints ���� ����
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // ���� ��ġ�� ù��° wayPoint ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        NextMoveTo();
        while (true)
        {
            if(Vector3.Distance(transform.position,wayPoints[currentIndex].position)< 0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if (currentIndex < wayPointCount - 1)
        {
            if (currentIndex == 2)
            {
                transform.Rotate(0,180,0);
                this.GetComponent<SpriteRenderer>().flipY=flipFlag;
            }
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            transform.Rotate(0, 180, 0);
            this.GetComponent<SpriteRenderer>().flipY = flipFlag;
            transform.position = wayPoints[currentIndex].position;
            currentIndex = 1;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
    }

    public void OnDie()
    {
        enemySpawner.DestroyEnemy(this);
    }
    

}
