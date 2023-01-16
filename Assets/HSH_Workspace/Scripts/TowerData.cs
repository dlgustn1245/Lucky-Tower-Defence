using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [SerializeField]
    private int tGold = 10;
    //Ÿ���̸�
    [SerializeField]
    private string tName = "T1";
    //���ݼӵ�
    [SerializeField]
    private float attackRate = 0.5f;
    //���ݹ���
    [SerializeField]
    private float attackRange = 2.0f;
    //���ݷ�
    [SerializeField]
    private int attackDamage = 1;
    //����
    private int level = 0;

    public int towerGold => tGold;
    public string Name => tName;
    public float Damage => attackDamage;
    public float Rate => attackRate;
    public float Range => attackRange;
    public int Level => level + 1;
}
