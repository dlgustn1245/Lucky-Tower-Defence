using System.Collections.Generic;
using UnityEngine;

public class MonsterObjectPoolManager : Singleton<MonsterObjectPoolManager>
{
    public List<MonsterPoolObjectData> poolObjectDataList = new List<MonsterPoolObjectData>();
    public Transform monsterParent, hpBarCanvas;
    public GameObject hpBar;
    public Dictionary<MonsterController, GameObject> monsterHpDic;

    Dictionary<string, Queue<MonsterController>> poolDict;
    Dictionary<string, MonsterPoolObjectData> dataDict;
    Queue<GameObject> hpBarQueue;

    new void Awake()
    {
        base.Awake();
    }
    
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
        monsterHpDic = new Dictionary<MonsterController, GameObject>();
        poolDict = new Dictionary<string, Queue<MonsterController>>(len);

        hpBarQueue = new Queue<GameObject>(GameManager.Instance.monsterCountLimit);
        CreateHpBarClone(ref hpBarQueue);

        foreach (var data in poolObjectDataList)
        {
            Register(data);
        }
    }

    void CreateHpBarClone(ref Queue<GameObject> queue)
    {
        for (int i = 0; i < GameManager.Instance.monsterCountLimit; i++)
        {
            var hpBarClone = Instantiate(hpBar, hpBarCanvas, true);
            hpBarClone.SetActive(false);
            queue.Enqueue(hpBarClone);
        }
    }
    
    void Register(MonsterPoolObjectData data)
    {
        if (poolDict.ContainsKey(data.key))
        {
            return;
        }
        
        MonsterController monsterObj = data.prefab.GetComponent<MonsterController>();

        Queue<MonsterController> pool = new Queue<MonsterController>(data.maxObjectCount);
        for (int i = 0; i < data.maxObjectCount; i++)
        {
            MonsterController clone = monsterObj.Clone();
            pool.Enqueue(clone);
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

        var monster = pool.Dequeue();
        monster.gameObject.SetActive(true);
        return monster;
    }

    public GameObject GetHpBar()
    {
        var bar = hpBarQueue.Dequeue();
        bar.SetActive(true);
        return bar;
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
            pool.Enqueue(monster);
            monster.gameObject.SetActive(false);
        }
        else
        {
            Destroy(monster.gameObject);
        }
    }

    public void ReturnHpBar(MonsterController monster)
    {
        if (!monsterHpDic.TryGetValue(monster, out var hpBarObj))
        {
            return;
        }

        monsterHpDic.Remove(monster);
        hpBarQueue.Enqueue(hpBarObj);
        hpBarObj.SetActive(false);
    }
}