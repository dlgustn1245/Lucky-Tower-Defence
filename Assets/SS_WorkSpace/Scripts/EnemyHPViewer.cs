using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    private MonsterController monsterController;
    private Slider hpSlider;

    public void Setup(MonsterController monsterController)
    {
        this.monsterController = monsterController;
        hpSlider = GetComponent<Slider>();
    }

    void Update()
    {
        hpSlider.value = monsterController.currHP / monsterController.maxHP;
    }
}
