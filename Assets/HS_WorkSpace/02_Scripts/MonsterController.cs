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

    public MonsterObjectPoolManager objectPoolManager;

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
        GameObject go = Instantiate(this.gameObject);
        go.SetActive(false);
        return go.GetComponent<MonsterController>();
    }

    public void TakeDamage(int dmg, GameObject tower)
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
                //print("gold : " + tower.GetComponent<TowerController>().tower.gold);
            }

            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        //objectPooling.InactivatePoolItem(gameObject);
        //Destroy(this.gameObject);
        objectPoolManager.ReturnMonster(this);
    }
}