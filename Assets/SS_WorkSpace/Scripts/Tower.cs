using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ÿ�� ��� ������
public enum TowerGrade { Epic, Legendary, Unique, Rare, Uncommon, Common}

[System.Serializable]
public class Tower
{
    public string towerName;
    public int towerAtk;
    public GameObject towerPrefabs;
    public TowerGrade towerGrade;
    public int weight;

    public Tower(Tower tower)//�Ű������� Ÿ���� �޴� ������
    {
        //Ÿ�� ��� �ʱ�ȭ
        this.towerName = tower.towerName;
        this.towerPrefabs = tower.towerPrefabs;
        this.towerGrade = tower.towerGrade;
        this.weight = tower.weight;
    }
}
