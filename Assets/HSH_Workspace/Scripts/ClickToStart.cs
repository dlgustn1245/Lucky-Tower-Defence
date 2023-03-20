using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    [SerializeField]
    public GameObject stepScene;
    [SerializeField]
    public GameObject basicPanel;
    [SerializeField]
    public GameObject startScene;

    // Start is called before the first frame update
    void Start()
    {
        /*stepScene.SetActive(false);
        basicPanel.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            stepScene.SetActive(true);
            basicPanel.SetActive(true);
            startScene.SetActive(false);
        }
    }
}
