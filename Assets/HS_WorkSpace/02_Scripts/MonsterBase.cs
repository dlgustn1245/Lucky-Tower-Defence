 using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [Header("Monster Stat")]
    public int hp;

    public void OnHit(int dmg)
    {
        print("Hit");
        if(hp <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        hp -= dmg;
    }
}