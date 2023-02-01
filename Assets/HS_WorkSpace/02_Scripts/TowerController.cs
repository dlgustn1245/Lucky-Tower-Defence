using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    Animator anim;
    GameObject targetMonster;

    public Tower tower;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        this.gameObject.GetComponent<CircleCollider2D>().radius = tower.range;
        print(tower.range);
        StartCoroutine(Attack());   
    }

    void Update()
    {
        
    }

    void Attack(GameObject monster, GameObject instigator)
    {
        if (!monster)
        {
            print("No monster");
            return;
        }
        monster.GetComponent<MonsterController>().TakeDamage(tower.damage, instigator);
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            if (GameManager.Instance.monsterList.Count > 0)
            {
                foreach (var monster in GameManager.Instance.monsterList)
                {
                    if (monster.Value) //bool
                    {
                        targetMonster = monster.Key;
                        break;
                    }
                }
                Attack(targetMonster, this.gameObject);
            }
            yield return new WaitForSeconds(tower.attackSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            print("Detect Enemy");
            GameManager.Instance.monsterList[collision.gameObject] = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            print("Exit Enemy");
            GameManager.Instance.monsterList[collision.gameObject] = false;
        }
    }
}