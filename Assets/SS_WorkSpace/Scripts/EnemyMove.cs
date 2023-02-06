using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private int wayPointCount;          // 이동 경로 개수
    private Transform[] wayPoints;      // 이동 경로 정보
    private int currentIndex = 0;       // 현재 목표지점 인덱스
    private Movement2D movement2D;
    private bool flipFlag = false;


    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        // 적 이동 경로 WayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // 적의 위치를 첫번째 wayPoint 위치로 설정
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
    
}
