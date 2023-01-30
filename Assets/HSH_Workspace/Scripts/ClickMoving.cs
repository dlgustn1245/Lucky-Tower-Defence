using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    public Camera cam;

    private bool isMove;
    private Vector3 destination;

    private Ray ray;
    private RaycastHit hit;

    private GameObject target;
    private bool selected = false;

    private Vector3 mousePos, transPos, destPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 클릭
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;
                Debug.Log(objectName);
            }
            selected = true;
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
