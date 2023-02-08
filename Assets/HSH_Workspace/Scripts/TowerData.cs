using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public enum Grade { Common, Uncommon, Rare, Unique, Legendary, Epic }
    [System.NonSerialized] 
    public Grade grade;
    
    [SerializeField]
    private int gold = 10;
    //타워이름
    [SerializeField]
    private string towerName = "T1";
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

    public string TowerName
    {
        get => towerName;
        set => towerName = value;
    }

    public int Damage
    {
        get => attackDamage;
        set => attackDamage = value;
    }
    public float Rate
    {
        get => attackRate;
        set => attackRate = value;
    }
    public float Range{
        get => attackRange;
        set => attackRange = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }
}
