using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
    public List<Tower> towers = new List<Tower>();
    [SerializeField]
    private int total = 0;

    public Tower RandomTower()
    {
        return towers[Random.Range(0, towers.Count)] ;
    }

    void Start()
    {
        for(int i=0; i < towers.Count; i++)
        {
            total += towers[i].weight;
        }
    }
}
