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

    protected Queue<GameObject> monsterList = new Queue<GameObject>();
    #endregion


    void Start()
    {

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
        yield return new WaitUntil(() => monsterList.Count > 0);
        while (true)
        {
            if (monsterList.Count > 0)
            {
                Attack(monsterList.Peek());
            }

            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
