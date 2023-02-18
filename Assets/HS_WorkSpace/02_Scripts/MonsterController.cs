using System;
using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("Monster Stat")]
    public float maxHP;
    public float currHP;
    public string key;
    public EnemyGrade enemyGrade;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currHP = maxHP;
    }

    void OnDisable()
    {
        this.gameObject.transform.position = new Vector3(0.0f, 3.5f, 0.0f);
    }

    public MonsterController Clone()
    {
        GameObject go = Instantiate(this.gameObject, MonsterObjectPoolManager.Instance.parent, true);
        go.SetActive(false);
        return go.GetComponent<MonsterController>();
    }

    public void TakeDamage(int dmg)
    {
        currHP -= dmg;
        if(currHP <= 0)
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
            }

            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        MonsterObjectPoolManager.Instance.ReturnMonster(this);
    }
}