using System;
using System.Collections;
using System.Collections.Generic;
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
    Animator anim;
    GameObject targetMonster;

    public Tower tower;
    public Boundary boundary;
    public bool isClicked;
    public Vector2 destination = Vector2.zero;

    float speed = 10.0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //this.gameObject.GetComponent<CircleCollider2D>().radius = tower.range;
        //print(tower.range);
        StartCoroutine(Attack());   
    }

    void Update()
    {
        if (isClicked)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, destination, Time.deltaTime * 10.0f);
            if (Vector2.Distance(this.transform.position, destination) < 0.1f)
            {
                isClicked = false;
                destination = Vector2.zero;
            }
        }

        if (!IsPositionInRange())
        {
            isClicked = false;
            destination = Vector2.zero;
        }
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
            //print("Detect Enemy");
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