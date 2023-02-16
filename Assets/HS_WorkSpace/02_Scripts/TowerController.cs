using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}

public class TowerController : MonoBehaviour
{
    GameObject targetMonster;

    public Tower tower;
    public Boundary boundary;
    public bool isClicked;
    public Vector2 destination = Vector2.zero;
    public Animator towerAnim;
    public float moveSpeed = 5.0f;

    bool runAnimTrigger;

    float speed = 10.0f;

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
            runAnimTrigger = true;
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

    void Attack(GameObject monster, GameObject instigator)
    {
        if (!monster)
        {
            return;
        }
        towerAnim.SetTrigger("Attack");
        monster.GetComponent<MonsterController>().TakeDamage(tower.damage, instigator);
    }

    public TowerController Clone()
    {
        GameObject go = Instantiate(this.gameObject);
        go.SetActive(false);
        return go.GetComponent<TowerController>();
    }

    IEnumerator Attack()
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
            GameManager.Instance.monsterList[collision.gameObject] = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //print("Exit Enemy");
            GameManager.Instance.monsterList[collision.gameObject] = false;
        }
    }
}