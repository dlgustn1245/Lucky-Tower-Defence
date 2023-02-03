using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("Monster Stat")]
    public int maxHP;
    public int currentHP;
    Animator anim;

    void Awake()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void TakeDamage(int dmg, GameObject tower)
    {
        print("Hit");
        currentHP -= dmg;
        if(currentHP <= 0)
        {
            print("Monster Dead");
            anim.SetTrigger("Die");
            GameManager.Instance.monsterList.Remove(this.gameObject);
            --GameManager.Instance.currMonsterCount;
            ++GameManager.Instance.killedMonster;
            GameManager.Instance.SetMonsterCountText();
            if (GameManager.Instance.killedMonster % 2 == 0)
            {
                ++tower.GetComponent<TowerController>().tower.gold;
                print("gold : " + tower.GetComponent<TowerController>().tower.gold);
            }

            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}