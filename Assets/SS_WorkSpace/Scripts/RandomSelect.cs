using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
    public List<GameObject> towers = new List<GameObject>();
    public Transform spawnPosition;
    
    int total = 0;
    GameObject result;
    
    public void ResultSelect()
    {
        result = RandomTower();
        Instantiate(result, spawnPosition.position, Quaternion.identity); //����������Ʈ, ������ġ(������), �����ɰ���
    }
    
    public GameObject RandomTower() //ȣ��� Ÿ�� ����Ʈ���� ����ġ�� ���� ������ Ÿ�� ��ȯ
    {
        int weight = 0;                                                   //����ġ ����
        int selectNum = Mathf.RoundToInt(total*Random.Range(0.0f,1.0f)); //�Ǽ� 0~1������ �����ǰ��� total�� ����
        
        for (int i = 0; i < towers.Count; i++)
        {
            weight += towers[i].GetComponent<TowerController>().tower.weight;
            if(selectNum <= weight)                                       //����ġ���� ������ �ش� Ÿ�� ��ȯ
            {
                return towers[i];
            }
        }
        return null;
    }

    void Start()
    {
        for(int i=0; i < towers.Count; i++)
        {
            total += towers[i].GetComponent<TowerController>().tower.weight;
        }
    }
}
