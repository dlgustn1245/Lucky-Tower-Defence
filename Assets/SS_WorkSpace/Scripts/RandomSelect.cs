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
        Instantiate(result, spawnPosition.position, Quaternion.identity); //생성오브젝트, 생성위치(포지션), 생성될각도
    }
    
    public GameObject RandomTower() //호출시 타워 리스트에서 가중치를 통한 임의의 타워 반환
    {
        int weight = 0;                                                   //가중치 변수
        int selectNum = Mathf.RoundToInt(total*Random.Range(0.0f,1.0f)); //실수 0~1사이의 임의의값을 total에 곱함
        
        for (int i = 0; i < towers.Count; i++)
        {
            weight += towers[i].GetComponent<TowerController>().tower.weight;
            if(selectNum <= weight)                                       //가중치보다 작으면 해당 타워 반환
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
