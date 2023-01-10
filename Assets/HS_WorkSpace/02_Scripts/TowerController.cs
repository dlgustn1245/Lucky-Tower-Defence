using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : TowerBase
{
    void Start()
    {
        StartCoroutine(base.Attack());   
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            print("Detect Enemy");
            monsterList.Enqueue(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        foreach(var go in monsterList)
        {
            if(go == collision.gameObject)
            {
                print("Exit");
                monsterList.Dequeue();
                break;
            }
        }
    }
}