using System;
using System.Collections.Generic;

public class TowersByGrade : Singleton<TowersByGrade>
{
    public List<TowerController> commons;
    public List<TowerController> uncommons;
    public List<TowerController> rares;
    public List<TowerController> uniques;
    public List<TowerController> epics;
    public List<TowerController> legendary;

    new void Awake()
    {
        base.Awake();
    }
    
    void Start()
    {
        
    }
}