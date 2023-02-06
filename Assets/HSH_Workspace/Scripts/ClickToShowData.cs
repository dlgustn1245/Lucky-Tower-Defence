using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowData : MonoBehaviour
{
    [SerializeField]
    private TowerDataViewer towerDataViewer;
    [SerializeField]
    private GameObject SpawnPos;

    private Vector2 mousePos;
    private Camera cam;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        //오른쪽 버튼
        if (Input.GetMouseButtonDown(1))
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
            }
        }
    }
}
