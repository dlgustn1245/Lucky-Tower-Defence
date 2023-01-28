using System.Collections;
using UnityEngine;

public enum Grade { S, A, B, C }

public class TowerBase : MonoBehaviour
{
    #region Fields
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
