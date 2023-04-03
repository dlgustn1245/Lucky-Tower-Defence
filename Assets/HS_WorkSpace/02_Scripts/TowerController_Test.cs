using System;
using System.Collections;
using UnityEngine;

public class TowerController_Test : MonoBehaviour
{
    GameObject targetMonster;

    public Tower tower;
    public Boundary boundary;
    public bool isClicked;
    public Vector2 destination = Vector2.zero;
    public Animator towerAnim;
    public float moveSpeed = 5.0f;

    bool runAnimTrigger;

    void OnEnable()
    {
        StartCoroutine(Attack());
    }

    void OnDisable()
    {
        this.gameObject.transform.position = Vector2.zero;
    }

    void Update()
    {
        if (isClicked)
        {
            //runAnimTrigger = true;
            this.transform.position = Vector2.MoveTowards(this.transform.position, destination, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(this.transform.position, destination) < 0.1f)
            {
                isClicked = false;
                destination = Vector2.zero;
                //towerAnim.SetBool("Run", false);
            }
        }

        if (!IsPositionInRange())
        {
            isClicked = false;
            destination = Vector2.zero;
            //towerAnim.SetBool("Run", false);
        }
        
        #region Animation

        if (runAnimTrigger)
        {
            runAnimTrigger = false;
            //towerAnim.SetBool("Run", true);
        }
        #endregion
    }

    bool IsPositionInRange()
    {
        var position = this.transform.position;
        return (position.x >= boundary.xMin && position.x <= boundary.xMax) && (position.y >= boundary.yMin && position.y <= boundary.yMax);
    }

    void Attack(GameObject monster)
    {
        if (monster is null)
        {
            return;
        }
        towerAnim.SetTrigger("Attack");
        monster.GetComponent<MonsterController>().TakeDamage(tower.damage);
    }

    public TowerController Clone()
    {
        GameObject go = Instantiate(this.gameObject, TowerObjectPoolManager.Instance.parent, true);
        go.SetActive(false);
        return go.GetComponent<TowerController>();
    }

    #region Upgrade
    public void UpgradeCommon()
    {
        print("Common Upgrade");
    }
    public void UpgradeUnCommon()
    {
        print("UnCommon Upgrade");
    }
    public void UpgradeRare()
    {
        print("Rare Upgrade");
    }
    public void UpgradeUnique()
    {
        print("Unique Upgrade");
    }
    public void UpgradeEpic()
    {
        print("Epic Upgrade");
    }
    public void UpgradeLegendary()
    {
        print("Legendary Upgrade");
    }
    #endregion

    IEnumerator Attack()
    {
        while (true)
        {
            // if (GameManager.Instance.monsterList.Count > 0)
            // {
            //     foreach (var monster in GameManager.Instance.monsterList)
            //     {
            //         if (monster.Value) //bool
            //         {
            //             targetMonster = monster.Key;
            //             break;
            //         }
            //     }
            //     Attack(targetMonster);
            // }

            float minDistance = Mathf.Infinity;
            for (int i = 0; i < GameManager.Instance.monsterList.Count; i++)
            {
                float distance = Vector2.Distance(GameManager.Instance.monsterList[i].transform.position, this.transform.position);
                if (distance <= tower.range && distance <= minDistance)
                {
                    minDistance = distance;
                    targetMonster = GameManager.Instance.monsterList[i];
                }
            }
            Attack(targetMonster);
            yield return new WaitForSeconds(tower.attackSpeed);
        }
    }
}