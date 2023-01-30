using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    public Camera cam;

    private bool isMove;
    private Vector3 destination;

    //마우스가 선택한 오브젝트
    private GameObject target;
    private bool selected = false;

    public GameObject[] towers;

    private Vector3 mousePos, transPos, destPos;
    private Vector3 startPos;

    private GameObject GetClickedObject()
    {
        RaycastHit hit;

        GameObject target = null;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        /*if (gameObject.tag == "Tower")
        {
            target = gameObject;
            Debug.Log(target.name);
        }*/

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.collider.gameObject.name);
            //타워 정보 출력
            if (hit.transform.CompareTag("Tower"))
            {
                selected = true;
                target = hit.collider.gameObject;
                //towerDataViewer.OnPanel(target.transform);
            }
        }

        return target;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //오른쪽 클릭
        if (Input.GetMouseButtonDown(1))
        {
            target = GetClickedObject();

            if (true == target.Equals(gameObject))
            {
                selected = true;
            }
        }
        ///오른쪽 클릭
        if (Input.GetMouseButtonDown(0) && selected == true)
        {
            CalDestPos();
        }

        if (selected == true)
        {
            MoveToDest();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            selected = false;
        }
    }

    void CalDestPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        destPos = new Vector3(transPos.x, transPos.y, 0);
    }

    void MoveToDest()
    {
        transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * 10f);
    }
}
