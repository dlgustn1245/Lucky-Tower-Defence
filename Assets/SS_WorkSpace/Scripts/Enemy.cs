using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyGrade { Low, Boss }

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public GameObject enemyPrefabs;
    public EnemyGrade enemyGrade;
    public int enemyHP;

    public Enemy(Enemy enemy)//매개변수로 타워를 받는 생성자
    {
        //타워 목록 초기화
        this.enemyName = enemy.enemyName;
        this.enemyPrefabs = enemy.enemyPrefabs;
        this.enemyGrade = enemy.enemyGrade;
        this.enemyHP = enemy.enemyHP;
    }
}
