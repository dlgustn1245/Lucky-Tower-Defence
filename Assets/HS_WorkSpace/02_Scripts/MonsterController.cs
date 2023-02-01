using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("Monster Stat")]
    public int hp;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void TakeDamage(int dmg)
    {
        print("Hit");
        hp -= dmg;
        if(hp <= 0)
        {
            print("Monster Dead");
            GameManager.Instance.monsterList.Remove(this.gameObject);
            --GameManager.Instance.currMonsterCount;
            ++GameManager.Instance.killedMonster;
            GameManager.Instance.SetMonsterCountText();
            if (GameManager.Instance.killedMonster % 2 == 0)
            {
                ++GameManager.Instance.gold;
                print(GameManager.Instance.gold);
            }
            Destroy(this.gameObject);
        }
    }
}