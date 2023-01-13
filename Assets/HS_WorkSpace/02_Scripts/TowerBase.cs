using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerGrade { Epic, Legendary, Unique, Rare, Uncommon, Common }

public class TowerBase : MonoBehaviour
{
    #region Fields
    [System.NonSerialized]
    public TowerGrade grade;

    [Header("Tower Stat")]
    public string towerName;
    public float attackRange;
    public float maxAttackRange;
    public float attackSpeed;
    public float maxAttackSpeed;
    public int attackDamage;
    public int maxAttackDamage;

    GameObject targetMonster;
    protected int monsterIdx = 100;
    #endregion

    void Start()
    {
        //Add monster to list each time spawned
    }

    void Update()
    {

    }

    void Attack(GameObject monster)
    {
        monster.GetComponent<MonsterController>().OnHit(attackDamage);
    }

    public IEnumerator Attack()
    {
        yield return new WaitUntil(() => GameManager.Instance.monsterList.Count > 0); //initial delay
        while (true)
        {
            if (GameManager.Instance.monsterList.Count > 0)
            {
                foreach (var monster in GameManager.Instance.monsterList)
                {
                    if(monster.Value == true)
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
}
