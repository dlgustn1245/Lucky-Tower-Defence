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