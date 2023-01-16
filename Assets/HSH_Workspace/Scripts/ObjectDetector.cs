using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerDataViewer towerDataViewer;
    [SerializeField]
    private TowerSpawner towerSpawner;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private GameObject target;
    Vector3 mousePos, targetPos, transPos;

    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        //왼쪽 클릭
        if (Input.GetMouseButtonDown(1))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                //타워 정보 출력
                if (hit.transform.CompareTag("Tower"))
                {
                    selected = true;
                    target = hit.collider.gameObject;
                    towerDataViewer.OnPanel(target.transform);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                //타워 클릭 이동
                if (hit.transform.CompareTag("Tile"))
                {
                    if (selected == true)
                    {
                        mousePos = Input.mousePosition;
                        transPos = mainCamera.ScreenToWorldPoint(mousePos);
                        targetPos = new Vector3(transPos.x, transPos.y, 0);

                        target.transform.position = targetPos;
                    }
                    selected = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            towerSpawner.SpawnTower();
        }
    }
}
