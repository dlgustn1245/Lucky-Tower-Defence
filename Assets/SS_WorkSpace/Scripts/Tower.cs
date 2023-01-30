using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ÿ�� ��� ������
public enum TowerGrade1 { Epic, Legendary, Unique, Rare, Uncommon, Common}

[System.Serializable]
public class Tower
{
    public string towerName;
    public int towerAtk;
    public GameObject towerPrefabs;
    public TowerGrade1 towerGrade;
    public int weight;
    public float towerMoveSpeed;
    public float towerAtkSpeed;

    public Tower(Tower tower)//�Ű������� Ÿ���� �޴� ������
    {
        //Ÿ�� ��� �ʱ�ȭ
        this.towerName = tower.towerName;
        this.towerPrefabs = tower.towerPrefabs;
        this.towerGrade = tower.towerGrade;
        this.weight = tower.weight;
        this.towerMoveSpeed = tower.towerMoveSpeed;
        this.towerAtkSpeed = tower.towerAtkSpeed;

    }
}
