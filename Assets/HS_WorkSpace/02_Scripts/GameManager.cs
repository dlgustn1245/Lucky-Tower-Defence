using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<GameObject, bool> monsterList = new Dictionary<GameObject, bool>();
    public int monsterCount = 0;
    int monsterCountLimit = 100;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(monsterCount >= monsterCountLimit)
        {
            //game over;
        }
    }
}
