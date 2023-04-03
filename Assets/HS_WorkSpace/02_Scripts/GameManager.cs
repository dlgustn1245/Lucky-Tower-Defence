using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> monsterList = new List<GameObject>();
    public Text timer, monsterCount, round, goldText;
    public int currMonsterCount;
    public int currWave;
    public int killedMonster;
    public GameObject menuPanel;
    public GameObject[] maps;

    public int gold;

    public int monsterCountLimit;
    public int maxStage;

    public bool gameStart = false;

    int currStage;
    int roundToClear;

    new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        SetText();
        StartCoroutine(InitialTimer());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextStage();
        }
    }

    public void UpdateMaps(int idx)
    {
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        maps[idx].SetActive(true);
    }

    public void NextStage()
    {
        ++currStage;
        if (currStage < maxStage)
        {
            UpdateMaps(currStage);
        }
        else
        {
            LoadGameOverScene();
        }
    }

    public void LoadGameOverScene()
    {
        PlayerPrefs.SetInt("MonsterCount", killedMonster);
        PlayerPrefs.SetInt("ClearRound", currWave - 1);
        SceneManager.LoadScene("GameOverScene");
    }

    IEnumerator InitialTimer()
    {
        var delay = new WaitForSeconds(1.0f);
        for (int i = 10; i > 0; i--)
        {
            var min = Mathf.FloorToInt(i / 60);
            var sec = Mathf.FloorToInt(i % 60);
            
            timer.text = string.Format("{0:00}:{1:00}", min, sec);
            yield return delay;
        }

        gameStart = true;
    }

    public IEnumerator StageTimer(float time)
    {
        var delay = new WaitForSeconds(1.0f);
        for (int i = Convert.ToInt32(time); i > 0; i--)
        {
            var min = Mathf.FloorToInt(i / 60);
            var sec = Mathf.FloorToInt(i % 60);
            
            timer.text = string.Format("{0:00}:{1:00}", min, sec);
            yield return delay;
        }
    }

    public void SetText()
    {
        monsterCount.text = currMonsterCount.ToString();
        goldText.text = gold.ToString();
        round.text = currWave.ToString();
    }
}