using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerGrade { S, A ,B, C}        //타워 등급 열거형

[System.Serializable]
public class Tower
{
    public string towerName;
    public Sprite towerImage;
    public TowerGrade towerGrade;
    public int weight;

    public Tower(Tower tower) //매개변수로 타워를 받는 생성자
    {
        //타워 목록 초기화
        this.towerName = tower.towerName;
        this.towerImage = tower.towerImage;
        this.towerGrade = tower.towerGrade;
        this.weight = tower.weight;
    }
}
