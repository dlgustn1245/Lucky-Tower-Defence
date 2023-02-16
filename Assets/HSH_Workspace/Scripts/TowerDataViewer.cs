using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.SpriteAssetUtilities;

public class TowerDataViewer : MonoBehaviour
{
    public Text gradeText;
    public Text dmgText;
    public Text atkSpeedText;

    Tower currentTower;
    TowerData currentTower_data;

    // Start is called before the first frame update
    void Start()
    {
        OffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform cTower)
    {
        //출력해야하는 타워 정보를 받아와서 저장
        currentTower = cTower.GetComponent<TowerController>().tower;
        //타워 정보 Panel On
        gameObject.SetActive(true);
        //타워 정보를 갱신
        UpdateTowerData();
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }

    void UpdateTowerData()
    {
        string grade = String.Empty;
        switch (currentTower.grade)
        {
            case TowerGrade.Common1:
            case TowerGrade.Common2:
            case TowerGrade.Common3:
            {
                grade = "Common";
                break;
            }
            case TowerGrade.UnCommon1:
            case TowerGrade.UnCommon2:
            case TowerGrade.UnCommon3:
            {
                grade = "UnCommon";
                break;
            }
            case TowerGrade.Rare1:
            case TowerGrade.Rare2:
            case TowerGrade.Rare3:
            {
                grade = "Rare";
                break;
            }
            case TowerGrade.Unique1:
            case TowerGrade.Unique2:
            case TowerGrade.Unique3:
            {
                grade = "Unique";
                break;
            }
            case TowerGrade.Epic1:
            case TowerGrade.Epic2:
            {
                grade = "Epic";
                break;
            }
            case TowerGrade.Legendary:
                grade = "Legendary";
                break;
        }
        gradeText.text = "Grade: " + grade;
        dmgText.text = "AtkDamage : " + currentTower.damage;
        atkSpeedText.text = "AtkSpeed : " + currentTower.attackSpeed;
    }
}