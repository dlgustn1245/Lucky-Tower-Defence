using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonEvent : MonoBehaviour
{
    public GameObject menuPanel;
    public UnityEngine.UI.Text pauseButtonText, speedUpButtonText;

    bool isPaused;
    bool isSpeedUpActivated;
    int pauseCnt;

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
}
