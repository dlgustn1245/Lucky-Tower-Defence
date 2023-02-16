using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonEvent : MonoBehaviour
{
    public GameObject menuPanel;
    public UnityEngine.UI.Text pauseButtonText, speedUpButtonText;
    public ClickMoving info;
    public GameObject upgradePanel, towerInfo;
    public TowerObjectPoolManager objectPoolManager;
    
    string grade;
    bool isPaused;
    bool isSpeedUpActivated;
    int pauseCnt;
    bool state;
    string towerGrade;

    Stack<TowerController> towerStack;
    TowerController currentTower;
    
    void Start()
    {
        pauseCnt = PlayerPrefs.GetInt("PauseCount", 2);
    }
    
    #region PanelMenu
    public void OnClickPause()
    {
        if (!isPaused)
        {
            if (pauseCnt == 0)
            {
                return;
            }
            isPaused = true;
            --pauseCnt;
            pauseButtonText.text = "계속하기";
            Time.timeScale = 0.0f;
        }
        else
        {
            isPaused = false;
            pauseButtonText.text = "일시정지 : " + pauseCnt;
            Time.timeScale = 1.0f;
        }
    }

    public void OnClickToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnClickClose()
    {
        menuPanel.SetActive(false);
    }

    public void OnClickSpeedUp()
    {
        if (isPaused)
        {
            return;
        }
        
        if (!isSpeedUpActivated)
        {
            isSpeedUpActivated = true;
            speedUpButtonText.text = "x1배속";
            Time.timeScale = 2.0f;

        }
        else
        {
            isSpeedUpActivated = false;
            speedUpButtonText.text = "x2배속";
            Time.timeScale = 1.0f;
        }
    }
    #endregion
    
    #region UpgradePanel
    public void UpgradeButton()
    {
        if (state == false)
        {
            upgradePanel.SetActive(true);
            state = true;
        }
        else
        {
            upgradePanel.SetActive(false);
            state = false;
        }
    }

    public void UpgradeCommon()
    {
        for (int i = 0; i < 3; i++)
        {
            towerGrade = Enum.GetName(typeof(TowerGrade), i);
            objectPoolManager.sampleDict[towerGrade].UpgradeCommon();
            towerStack = objectPoolManager.poolDict[towerGrade];
            foreach (var tower in towerStack)
            {
                tower.UpgradeCommon();
            }
        }
    }

    public void UpgradeUnCommon()
    {
        for (int i = 3; i < 6; i++)
        {
            towerGrade = Enum.GetName(typeof(TowerGrade), i);
            objectPoolManager.sampleDict[towerGrade].UpgradeUnCommon();
            towerStack = objectPoolManager.poolDict[towerGrade];
            foreach (var tower in towerStack)
            {
                tower.UpgradeUnCommon();
            }
        }
    }

    public void UpgradeRare()
    {
        for (int i = 6; i < 9; i++)
        {
            towerGrade = Enum.GetName(typeof(TowerGrade), i);
            objectPoolManager.sampleDict[towerGrade].UpgradeRare();
            towerStack = objectPoolManager.poolDict[towerGrade];
            foreach (var tower in towerStack)
            {
                tower.UpgradeRare();
            }
        }
    }

    public void UpgradeUnique()
    {
        for (int i = 9; i < 12; i++)
        {
            towerGrade = Enum.GetName(typeof(TowerGrade), i);
            objectPoolManager.sampleDict[towerGrade].UpgradeUnique();
            towerStack = objectPoolManager.poolDict[towerGrade];
            foreach (var tower in towerStack)
            {
                tower.UpgradeUnique();
            }
        }
    }

    public void UpgradeEpic()
    {
        for (int i = 12; i < 14; i++)
        {
            towerGrade = Enum.GetName(typeof(TowerGrade), i);
            objectPoolManager.sampleDict[towerGrade].UpgradeEpic();
            towerStack = objectPoolManager.poolDict[towerGrade];
            foreach (var tower in towerStack)
            {
                tower.UpgradeEpic();
            }
        }
    }

    public void UpgradeLegendary()
    {
        towerGrade = Enum.GetName(typeof(TowerGrade), 14);
        objectPoolManager.sampleDict[towerGrade].UpgradeLegendary();
        towerStack = objectPoolManager.poolDict[towerGrade];
        foreach (var tower in towerStack)
        {
            tower.UpgradeLegendary();
        }
    }
    #endregion
    
    public void SellTower()
    {
        currentTower = info.target.GetComponent<TowerController>();
        GameManager.Instance.gold += currentTower.GetComponent<TowerController>().tower.price;
        GameManager.Instance.SetText();
        towerInfo.SetActive(false);
        objectPoolManager.ReturnTower(currentTower);
    }
}
