using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ÿ�� ��� ������
//public enum TowerGrade1 { Epic, Legendary, Unique, Rare, Uncommon, Common }

[System.Serializable]
public class Tower_R
{
    public string towerName;
    public int towerAtk;
    public GameObject towerPrefabs;
    public TowerGrade1 towerGrade;
    public int weight;

    public Tower_R(Tower tower)//�Ű������� Ÿ���� �޴� ������
    {
        //Ÿ�� ��� �ʱ�ȭ
        this.towerName = tower.towerName;
        this.towerPrefabs = tower.towerPrefabs;
        this.towerGrade = tower.towerGrade;
        this.weight = tower.weight;
    }
}
