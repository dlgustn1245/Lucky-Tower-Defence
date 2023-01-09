using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerGrade { S, A ,B, C}        //Ÿ�� ��� ������

[System.Serializable]
public class Tower
{
    public string towerName;
    public Sprite towerImage;
    public TowerGrade towerGrade;
    public int weight;

    public Tower(Tower tower) //�Ű������� Ÿ���� �޴� ������
    {
        //Ÿ�� ��� �ʱ�ȭ
        this.towerName = tower.towerName;
        this.towerImage = tower.towerImage;
        this.towerGrade = tower.towerGrade;
        this.weight = tower.weight;
    }
}
