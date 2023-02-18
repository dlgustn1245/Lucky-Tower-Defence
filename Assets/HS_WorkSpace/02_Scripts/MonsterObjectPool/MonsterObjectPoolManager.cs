using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObjectPoolManager : MonoBehaviour
{
    public List<MonsterPoolObjectData> poolObjectDataList = new List<MonsterPoolObjectData>();

    Dictionary<string, Stack<MonsterController>> poolDict;
    Dictionary<string, MonsterPoolObjectData> dataDict;

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
        
        dataDict = new Dictionary<string, MonsterPoolObjectData>(len);
        poolDict = new Dictionary<string, Stack<MonsterController>>(len);

        foreach (var data in poolObjectDataList)
        {
            Register(data);
        }
    }
    
    void Register(MonsterPoolObjectData data)
    {
        if (poolDict.ContainsKey(data.key))
        {
            return;
        }
        
        MonsterController monsterObj = data.prefab.GetComponent<MonsterController>();

        Stack<MonsterController> pool = new Stack<MonsterController>(data.maxObjectCount);
        for (int i = 0; i < data.maxObjectCount; i++)
        {
            MonsterController clone = monsterObj.Clone();
            pool.Push(clone);
        }
        
        dataDict.Add(data.key, data);
        poolDict.Add(data.key, pool);
    }

    public MonsterController GetMonster(string key)
    {
        if (!poolDict.TryGetValue(key, out var pool))
        {
            return null;
        }

        var monster = pool.Pop();
        monster.gameObject.SetActive(true);
        return monster;
    }
    
    public void ReturnMonster(MonsterController monster)
    {
        if (!poolDict.TryGetValue(monster.key, out var pool))
        {
            return;
        }

        string key = monster.key;

        if (pool.Count < dataDict[key].maxObjectCount)
        {
            pool.Push(monster);
            monster.gameObject.SetActive(false);
        }
        else
        {
            Destroy(monster.gameObject);
        }
    }
}