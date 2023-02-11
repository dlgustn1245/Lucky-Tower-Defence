using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    [Header("Monster Stat")]
    public float maxHP;
    public float currentHP;
    public EnemyGrade enemyGrade;
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
        currentHP -= dmg;
        if(currentHP <= 0)
        {
            if (enemyGrade == EnemyGrade.Boss)
            {
                GameManager.Instance.gold += 10;
                GameManager.Instance.NextStage();
            }
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
        //objectPooling.InactivatePoolItem(gameObject);
        Destroy(this.gameObject);
    }
}