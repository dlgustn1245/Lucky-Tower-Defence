using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject menuPanel;
    public Text pauseButtonText;

    bool isPaused;
    int pauseCnt;

    void Start()
    {
        pauseCnt = PlayerPrefs.GetInt("PauseCount", 2);
        pauseButtonText.text = "일시정지 : " + pauseCnt;
    }

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

    public void OnClickClose()
    {
        menuPanel.SetActive(false);
    }
}
