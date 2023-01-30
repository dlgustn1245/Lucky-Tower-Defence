using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuilding : MonoBehaviour
{
    /*//타워 생성
    [SerializeField]
    public GameObject CreateTower;
    //타워 업그레이드
    [SerializeField]
    public GameObject UpgradeTower;*/

    /*public Camera mainCamera;
    public Ray ray;
    public RaycastHit hit;*/

    [SerializeField]
    TowerSpawner towerSpawner;

    public GameObject button;

    //마우스 클릭 좌표
    public void Create_Tower()
    {
        Debug.Log("CreateTower");
        towerSpawner.SpawnTower();
    }
}


