using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    MonsterController monsterController;
    Slider hpSlider;

    public void Setup(MonsterController monster)
    {
        monsterController = monster;
        hpSlider = GetComponent<Slider>();
    }

    void Update()
    {
        hpSlider.value = monsterController.currHP / monsterController.maxHP;
    }
}
