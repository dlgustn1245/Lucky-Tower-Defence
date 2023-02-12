using System.Collections.Generic;
using UnityEngine;

//reference : https://rito15.github.io/posts/unity-object-pooling/

[DisallowMultipleComponent]
public class ObjectPoolManager : MonoBehaviour
{
    public List<PoolObjectData> poolObjectDataList = new List<PoolObjectData>();

    Dictionary<string, PoolObject> sampleDict;
    Dictionary<string, PoolObjectData> dataDict;
    Dictionary<string, Stack<PoolObject>> poolDict;

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

        sampleDict = new Dictionary<string, PoolObject>(len);
        dataDict = new Dictionary<string, PoolObjectData>(len);
        poolDict = new Dictionary<string, Stack<PoolObject>>(len);

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
        if (!sample.TryGetComponent(out PoolObject po))
        {
            po = sample.AddComponent<PoolObject>();
            po.key = data.key;
        }
        sample.SetActive(false);

        Stack<PoolObject> pool = new Stack<PoolObject>(data.maxObjectCount);
        for (int i = 0; i < data.initialObjectCount; i++)
        {
            PoolObject clone = po.Clone();
            pool.Push(clone);
        }

        sampleDict.Add(data.key, po);
        dataDict.Add(data.key, data);
        poolDict.Add(data.key, pool);
    }

    public PoolObject Spawn(string key)
    {
        if (!poolDict.TryGetValue(key, out var pool))
        {
            return null;
        }

        PoolObject po = pool.Count > 0 ? pool.Pop() : sampleDict[key].Clone();
        po.gameObject.SetActive(true);
        return po;
    }

    public void Despawn(PoolObject po)
    {
        if (!poolDict.TryGetValue(po.key, out var pool))
        {
            return;
        }

        string key = po.key;

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