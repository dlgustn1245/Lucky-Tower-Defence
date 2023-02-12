using UnityEngine;

[System.Serializable]
public class PoolObjectData
{
    public const int initCount = 10;
    public const int maxCount = 50;

    public string key;
    public GameObject prefab;
    public int initialObjectCount = initCount;
    public int maxObjectCount = maxCount;
}