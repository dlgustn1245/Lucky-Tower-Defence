using Redcode.Pools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonEvent : MonoBehaviour
{
    public GameObject menuPanel;
    public UnityEngine.UI.Text pauseButtonText, speedUpButtonText;
    public ClickMoving info;
    public GameObject upgradePanel, towerInfo;
    public PoolManager poolManager;

    bool isPaused;
    bool isSpeedUpActivated;
    int pauseCnt;
    
    bool state;
    TowerController currentTower;
    
    void Start()
    {
        pauseCnt = PlayerPrefs.GetInt("PauseCount", 2);
    }
    
    #region InGameMenu
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
    
    #region Upgrade
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
        
    }

    public void UpgradeUnCommon()
    {

    }

    public void UpgradeRare()
    {

    }

    public void UpgradeUnique()
    {

    }

    public void UpgradeEpic()
    {

    }

    public void UpgradeLegendary()
    {

    }
    public void SellTower()
    {
        currentTower = info.target.GetComponent<TowerController>();
        GameManager.Instance.gold += currentTower.tower.price;
        GameManager.Instance.SetText();
        towerInfo.SetActive(false);
        poolManager.TakeToPool<TowerController>(currentTower.tower.grade.ToString(), currentTower);
    }
    #endregion
}
