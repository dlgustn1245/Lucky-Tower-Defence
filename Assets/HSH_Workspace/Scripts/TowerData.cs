using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [SerializeField]
    private int tGold = 10;
    //타워이름
    [SerializeField]
    private string tName = "T1";
    //공격속도
    [SerializeField]
    private float attackRate = 0.5f;
    //공격범위
    [SerializeField]
    private float attackRange = 2.0f;
    //공격력
    [SerializeField]
    private int attackDamage = 1;
    //레벨
    private int level = 0;

    public int towerGold => tGold;
    public string Name => tName;
    public float Damage => attackDamage;
    public float Rate => attackRate;
    public float Range => attackRange;
    public int Level => level + 1;
}
