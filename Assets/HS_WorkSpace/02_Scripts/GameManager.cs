using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                return null;
            }

            return instance;
        } 
    }
    
    public Dictionary<GameObject, bool> monsterList = new Dictionary<GameObject, bool>();
    public Text timer, monsterCount, round, goldText;
    public int currMonsterCount;
    public int currStage;
    public int currWave;
    public int killedMonster;
    public GameObject menuPanel;
    public GameObject[] maps;

    public bool gameClear = false;
    public bool gameOver = false;

    public int gold;

    public int monsterCountLimit;
    int roundToClear;
    int maxStage;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        SetText();
        UpdateMaps(0);
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

        if (gameClear || gameOver)
        {
            PlayerPrefs.SetInt("MonsterCount", killedMonster);
            PlayerPrefs.SetInt("ClearRound", currWave - 1);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void UpdateMaps(int idx)
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
            gameClear = true;
            PlayerPrefs.SetInt("MonsterCount", killedMonster);
            PlayerPrefs.SetInt("ClearRound", currWave - 1);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // IEnumerator RoundTimer()
    // {
    //     while (true)
    //     {
    //         for (int i = 10; i > 0; i--)
    //         {
    //             timer.text = i.ToString();
    //             yield return new WaitForSeconds(1.0f);
    //         }
    //         ++currRound;
    //         round.text = currRound.ToString();
    //     }
    // }

    public void SetText()
    {
        monsterCount.text = currMonsterCount.ToString();
        goldText.text = gold.ToString();
        round.text = currWave.ToString();
    }
}