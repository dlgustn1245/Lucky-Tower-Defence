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
        Instantiate(Tower, spawnPosition.position, Quaternion.identity); //생성오브젝트, 생성위치(포지션), 생성될각도  
    }
}
