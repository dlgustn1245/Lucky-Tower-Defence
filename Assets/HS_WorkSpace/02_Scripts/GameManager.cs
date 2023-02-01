using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<GameObject, bool> monsterList = new Dictionary<GameObject, bool>();
    public Text timer, monsterCount, round;
    public int currMonsterCount = 0;
    public int currRound = 1;
    public int killedMonster = 0;

    public bool gameClear = false;
    public bool gameOver = false;

    int monsterCountLimit = 100;
    int roundToClear = 100;

    new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        StartCoroutine(RountTimer());
    }
    
    void Update()
    {
        if(currMonsterCount >= monsterCountLimit)
        {
            print("Game Over");
            gameOver = true;
            StopAllCoroutines();
        }

        if (currRound >= roundToClear)
        {
            print("Game Clear");
            gameClear = true;
            StopAllCoroutines();
        }
    }

    IEnumerator RountTimer()
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

    public void SetMonsterCountText()
    {
        monsterCount.text = currMonsterCount.ToString();
    }
}