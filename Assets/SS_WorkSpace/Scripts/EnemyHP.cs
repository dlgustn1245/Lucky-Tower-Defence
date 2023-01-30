using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    private float currentHP;
    private bool isDie = false;
    private EnemyMove enemyMove;
    private Animator animator;

    void Awake()
    {
        currentHP = maxHP;
        enemyMove = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamge(float damage)
    {
        //이미 사망상태이면 실행 X
        if (isDie == true) return;

        currentHP -= damage; //damge만큼 체력 감소

        if(currentHP <=0)
        {
            animator.SetTrigger("Die");
            isDie = true;
            enemyMove.OnDie();
        }
        
    }
}
