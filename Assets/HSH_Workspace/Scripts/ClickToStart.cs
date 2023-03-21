using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    public GameObject basicPanel;
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
            GameManager.Instance.UpdateMaps(0);
            basicPanel.SetActive(true);
            startScene.SetActive(false);
        }
    }
}
