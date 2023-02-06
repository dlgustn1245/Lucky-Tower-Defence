using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyGrade { Low, Boss }

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefabs;
    public EnemyGrade enemyGrade;

    public Enemy(Enemy enemy)//�Ű������� Ÿ���� �޴� ������
    {
        //Ÿ�� ��� �ʱ�ȭ
        this.enemyPrefabs = enemy.enemyPrefabs;
        this.enemyGrade = enemy.enemyGrade;
    }
}
