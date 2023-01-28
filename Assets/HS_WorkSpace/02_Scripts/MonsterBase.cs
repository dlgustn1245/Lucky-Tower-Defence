using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [Header("Monster Stat")]
    public int hp;
    public float moveSpeed;

    public void OnHit(int dmg)
    {
        print("Hit");
        hp -= dmg;
        if(hp <= 0)
        {
            GameManager.Instance.monsterList.Remove(this.gameObject);
            Destroy(this.gameObject);
            return;
        }
    }
}