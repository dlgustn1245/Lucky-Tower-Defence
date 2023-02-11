using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("Monster Stat")]
    public float maxHP;
    public float currentHP;
    private ObjectPooling objectPooling;
    Animator anim;

    void Awake()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
    }

    public void Setup(ObjectPooling objectPooling)
    {
        this.objectPooling = objectPooling;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void TakeDamage(int dmg, GameObject tower)
    {
        {
            //print("Monster Dead");
            anim.SetTrigger("Die");
            GameManager.Instance.monsterList.Remove(this.gameObject);
            --GameManager.Instance.currMonsterCount;
            ++GameManager.Instance.killedMonster;
            GameManager.Instance.SetText();
            if (GameManager.Instance.killedMonster % 2 == 0)
            {
                ++GameManager.Instance.gold;
                //print("gold : " + tower.GetComponent<TowerController>().tower.gold);
            }

            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        objectPooling.DeactivatePoolItem(gameObject);
    }
}