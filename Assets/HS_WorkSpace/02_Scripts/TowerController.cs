using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    #region Fields
    public enum Grade { Common, Uncommon, Rare, Unique, Legendary, Epic }
    
    [System.NonSerialized] 
    public Grade grade;

    [Header("Tower Stat")] 
    public string towerName;
    public float attackRange;
    public float maxAttackRange;
    public float attackSpeed;
    public float maxAttackSpeed;
    public int attackDamage;
    public int maxAttackDamage;

    GameObject targetMonster;
    #endregion

    void Attack(GameObject monster)
    {
        if (!monster)
        {
            print("No monster");
            return;
        }
        monster.GetComponent<MonsterController>().TakeDamage(attackDamage);
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            if (GameManager.Instance.monsterList.Count > 0)
            {
                foreach (var monster in GameManager.Instance.monsterList)
                {
                    if (monster.Value)
                    {
                        targetMonster = monster.Key;
                        break;
                    }
                }
                Attack(targetMonster);
            }
            yield return new WaitForSeconds(attackSpeed);
        }
    }
    void Start()
    {
        StartCoroutine(Attack());   
    }

    void Update()
    {
        
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