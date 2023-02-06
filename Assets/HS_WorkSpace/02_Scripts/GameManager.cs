using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<GameObject, bool> monsterList = new Dictionary<GameObject, bool>();
    public Text timer, monsterCount, round, goldText;
    public int currMonsterCount = 0;
    public int currRound = 1;
    public int killedMonster = 0;
    public GameObject menuPanel;

    public bool gameClear = false;
    public bool gameOver = false;

    public int gold = 20;

    int monsterCountLimit = 100;
    int roundToClear = 100;

    new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        SetText();
        StartCoroutine(RoundTimer());
    }
    
    void Update()
    {
        if(currMonsterCount >= monsterCountLimit)
        {
            print("Game Over");
            gameOver = true;
            StopAllCoroutines();
            DestroyAllMonsters();
        }

        if (currRound >= roundToClear)
        {
            print("Game Clear");
            gameClear = true;
            StopAllCoroutines();
            DestroyAllMonsters();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }
    }

    void DestroyAllMonsters()
    {
        // foreach (var pair in monsterList)
        // {
        //     var go = pair.Key;
        //     Destroy(go);
        //     monsterList.Remove(go);
        // }
    }

    IEnumerator RoundTimer()
    {
        while (true)
        {
            for (int i = 10; i > 0; i--)
            {
                timer.text = i.ToString();
                yield return new WaitForSeconds(1.0f);
            }
            ++currRound;
            round.text = currRound.ToString();
        }
    }

    public void SetText()
    {
        monsterCount.text = currMonsterCount.ToString();
        goldText.text = gold.ToString();
    }
}