public enum TowerGrade { Common01 = 0, Common02, Common03, UnCommon01, UnCommon02, UnCommon03, Rare01, Rare02, Rare03, Unique01, Unique02, Unique03, Epic01, Epic02, Legendary }

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
