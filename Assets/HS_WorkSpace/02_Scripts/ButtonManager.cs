using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject menuPanel;
    public Text pauseButtonText, speedUpButtonText;

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

    #region TitleScene
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Stage");
    }

    public void OnClickQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion
}
