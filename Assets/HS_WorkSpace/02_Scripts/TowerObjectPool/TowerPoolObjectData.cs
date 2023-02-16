using UnityEngine;

[System.Serializable]
public class TowerPoolObjectData
{
    public const int initCount = 10;
    public const int maxCount = 50;

    public string key;
    public GameObject prefab;
    public int initialObjectCount = initCount;
    public int maxObjectCount = maxCount;
}