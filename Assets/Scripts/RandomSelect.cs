using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
    public List<Tower> towers = new List<Tower>();
    [SerializeField]
    private int total = 0;
    public List<Tower> result = new List<Tower>();

    public void ResultSelect()
    {
        result.Add(RandomTower());
    }
    public Tower RandomTower() //호출시 타워 리스트에서 가중치를 통한 임의의 타워 반환
    {
        int weight = 0;                                                   //가중치 변수
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total*Random.Range(0.0f,1.0f));      //실수 0~1사이의 임의의값을 total에 곱함
        for (int i = 0; i < towers.Count; i++)
        {
            weight += towers[i].weight;
            if(selectNum <= weight)                                       //가중치보다 작으면 해당 카드 반환
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
