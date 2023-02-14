using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowData : MonoBehaviour
{
    [SerializeField]
    private TowerDataViewer towerDataViewer;

    private Vector2 mousePos;
    private Camera cam;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        //left click
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, cam.transform.forward);

            if (hit)
			{
                //타워 정보 출력
                if (hit.transform.CompareTag("Tower"))
                {
                    target = hit.collider.gameObject;
                    towerDataViewer.OnPanel(target.transform);
                }
                else
                {
                    towerDataViewer.OffPanel();
                }
            }
        }
    }
}
