public enum TowerGrade { Common1 = 0, Common2, Common3, UnCommon1, UnCommon2, UnCommon3, Rare1, Rare2, Rare3, Unique1, Unique2, Unique3, Epic1, Epic2, Legendary }

[System.Serializable]
public class Tower
{
    public string towerName;
    public int damage;
    public TowerGrade grade;
    public float weight;
    public float attackSpeed;
    public float range;
    public int price;

    public Tower(Tower tower)//매개변수로 타워를 받는 생성자
    {
        //타워 목록 초기화
        this.towerName = tower.towerName;
        this.damage = tower.damage;
        this.grade = tower.grade;
        this.weight = tower.weight;
        this.attackSpeed = tower.attackSpeed;
        this.range = tower.range;
        this.price = tower.price;
    }
}
