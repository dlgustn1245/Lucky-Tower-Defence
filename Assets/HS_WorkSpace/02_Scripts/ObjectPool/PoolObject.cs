using UnityEngine;

[DisallowMultipleComponent]
public class PoolObject : MonoBehaviour
{
    public string key;
    
    public PoolObject Clone()
    {
        GameObject go = Instantiate(gameObject);
        if (!go.TryGetComponent(out PoolObject po))
        {
            po = go.AddComponent<PoolObject>();
        }
        go.SetActive(false);

        return po;
    }
}