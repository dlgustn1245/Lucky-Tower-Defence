using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Tower;
    public Transform spawnPosition;

    public void BuildToTower()
    {
        Instantiate(Tower, spawnPosition.position, Quaternion.identity); //����������Ʈ, ������ġ(������), �����ɰ���  
    }
}
