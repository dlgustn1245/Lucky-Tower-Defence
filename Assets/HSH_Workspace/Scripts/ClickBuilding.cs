using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuilding : MonoBehaviour
{
    /*//Ÿ�� ����
    [SerializeField]
    public GameObject CreateTower;
    //Ÿ�� ���׷��̵�
    [SerializeField]
    public GameObject UpgradeTower;*/

    /*public Camera mainCamera;
    public Ray ray;
    public RaycastHit hit;*/

    [SerializeField]
    TowerSpawner towerSpawner;

    public GameObject button;

    //���콺 Ŭ�� ��ǥ
    public void Create_Tower()
    {
        Debug.Log("CreateTower");
        towerSpawner.SpawnTower();
    }
}


