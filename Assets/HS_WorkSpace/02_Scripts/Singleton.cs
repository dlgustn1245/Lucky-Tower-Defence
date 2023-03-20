using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<T>();
                //DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    protected void Awake()
    {
        if (instance)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
            return;
        }
        instance = GetComponent<T>();
        //DontDestroyOnLoad(this.gameObject);
    }
}