using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyGrade { Low, Boss }

[System.Serializable]
public class Wave
{
    public EnemyGrade enemyGrade;
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject enemyPrefab;
}