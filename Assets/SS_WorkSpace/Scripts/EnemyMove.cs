using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    int wayPointCount; // �̵� ��� ����
    Transform[] wayPoints; // �̵� ��� ����
    int currentIndex = 0; // ���� ��ǥ���� �ε���
    Movement2D movement2D;
    bool flipFlag = false;

    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        // �� �̵� ��� WayPoints ���� ����
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // ���� ��ġ�� ù��° wayPoint ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;
        StartCoroutine(OnMove());
        print(0.03f * movement2D.MoveSpeed);
    }

    IEnumerator OnMove()
    {
        NextMoveTo();
        while (true)
        {
            if (Vector2.Distance(transform.position, wayPoints[currentIndex].position) < 0.03f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }

    void NextMoveTo()
    {
        if (currentIndex < wayPointCount - 1)
        {
            if (currentIndex == 2)
            {
                transform.Rotate(0, 180, 0);
                this.GetComponent<SpriteRenderer>().flipY = flipFlag;
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
}