using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
    public List<Tower> towers = new List<Tower>();
    [SerializeField]
    private int total = 0;
    public Tower result;
    public Transform spawnPosition;

 
    public void ResultSelect()
    {
        result= RandomTower();
        Instantiate(result.towerPrefabs, spawnPosition.position, Quaternion.identity); //����������Ʈ, ������ġ(������), �����ɰ���

    }
    public Tower RandomTower() //ȣ��� Ÿ�� ����Ʈ���� ����ġ�� ���� ������ Ÿ�� ��ȯ
    {
        int weight = 0;                                                   //����ġ ����
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total*Random.Range(0.0f,1.0f));      //�Ǽ� 0~1������ �����ǰ��� total�� ����
        for (int i = 0; i < towers.Count; i++)
        {
            weight += towers[i].weight;
            if(selectNum <= weight)                                       //����ġ���� ������ �ش� Ÿ�� ��ȯ
            {
                Tower temp = new Tower(towers[i]);
                return temp;
            }
        }
        return null;
    }

    void Start()
    {
        for(int i=0; i < towers.Count; i++)
        {
            total += towers[i].weight;
        }
    }
}
