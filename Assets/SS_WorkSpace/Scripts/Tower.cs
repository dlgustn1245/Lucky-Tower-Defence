using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//타워 등급 열거형
public enum TowerGrade { Epic, Legendary, Unique, Rare, Uncommon, Common}

[System.Serializable]
public class Tower
{
    public int damage;
    public TowerGrade grade;
    public int weight;
    public float attackSpeed;
    public float range;
    public int price;

    public Tower(Tower tower)//매개변수로 타워를 받는 생성자
    {
        //타워 목록 초기화
        this.damage = tower.damage;
        this.grade = tower.grade;
        this.weight = tower.weight;
        this.attackSpeed = tower.attackSpeed;
        this.range = tower.range;
        this.price = tower.price;
    }
}
