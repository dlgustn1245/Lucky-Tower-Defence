using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private PlayerGold playerGold;

    public void SpawnTower()
    {
        Vector2 spawnPos = new Vector2(0, 0);

        //선택한 타일의 위치에 타워 건설
        Instantiate(towerPrefab, spawnPos, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
