using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    public UnityEngine.UI.Text waveCount, monsterCount;
    
    void Start()
    {
        waveCount.text = PlayerPrefs.GetInt("ClearRound", 0).ToString();
        monsterCount.text = PlayerPrefs.GetInt("MonsterCount", 0).ToString();
    }
}
