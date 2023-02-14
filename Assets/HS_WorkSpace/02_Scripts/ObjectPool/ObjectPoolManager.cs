using System.Collections.Generic;
using UnityEngine;

//reference : https://rito15.github.io/posts/unity-object-pooling/

[DisallowMultipleComponent]
public class ObjectPoolManager : MonoBehaviour
{
    public List<PoolObjectData> poolObjectDataList = new List<PoolObjectData>();
    
    public Dictionary<string, Stack<TowerController>> poolDict;
    Dictionary<string, TowerController> sampleDict;
    Dictionary<string, PoolObjectData> dataDict;
    
    void Start()
    {
        Init();
    }

    void Init()
    {
        int len = poolObjectDataList.Count;
        if (len == 0)
        {
            return;
        }

        sampleDict = new Dictionary<string, TowerController>(len);
        dataDict = new Dictionary<string, PoolObjectData>(len);
        poolDict = new Dictionary<string, Stack<TowerController>>(len);

        foreach (var data in poolObjectDataList)
        {
            Register(data);
        }
    }

    void Register(PoolObjectData data)
    {
        if (poolDict.ContainsKey(data.key))
        {
            return;
        }

        GameObject sample = Instantiate(data.prefab);
        // if (!sample.TryGetComponent(out PoolObject po))
        // {
        //     po = sample.AddComponent<PoolObject>();
        //     po.key = data.key;
        // }
        TowerController towerObj = sample.GetComponent<TowerController>();
        sample.SetActive(false);

        Stack<TowerController> pool = new Stack<TowerController>(data.maxObjectCount);
        for (int i = 0; i < data.initialObjectCount; i++)
        {
            TowerController clone = towerObj.Clone();
            pool.Push(clone);
        }

        sampleDict.Add(data.key, towerObj);
        dataDict.Add(data.key, data);
        poolDict.Add(data.key, pool);
    }

    public TowerController GetTower(string key)
    {
        if (!poolDict.TryGetValue(key, out var pool))
        {
            return null;
        }

        TowerController tower = pool.Count > 0 ? pool.Pop() : sampleDict[key].Clone();
        tower.gameObject.SetActive(true);
        return tower;
    }

    public void ReturnTower(TowerController po)
    {
        if (!poolDict.TryGetValue(po.tower.towerName, out var pool))
        {
            return;
        }

        string key = po.tower.towerName;

        if (pool.Count < dataDict[key].maxObjectCount)
        {
            pool.Push(po);
            po.gameObject.SetActive(false);
        }
        else
        {
            Destroy(po.gameObject);
        }
    }
}