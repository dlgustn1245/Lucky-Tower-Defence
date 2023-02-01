using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    public Camera cam;

    //클릭된 오브젝트
    private GameObject target;
    private bool selected = false;

    public GameObject[] towers;

    private Vector3 mousePos, transPos, destPos;

    Vector2 MousePosition;

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
            Vector2 touchPos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, cam.transform.forward);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                selected = true;
                target = hit.collider.gameObject;
                Debug.Log(target);
            }
        }
        //왼쪽 버튼
        if (Input.GetMouseButtonDown(0) && selected)
        {
            MousePosition = Input.mousePosition;
            MousePosition = cam.ScreenToWorldPoint(MousePosition);

			transform.position = MousePosition;
            Debug.Log(MousePosition);
		}

        if (selected == true)
        {
            //MoveToDest();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            selected = false;
        }
    }

    void CalDestPos()
    {
        mousePos = Input.mousePosition;
        transPos = cam.ScreenToWorldPoint(mousePos);
        destPos = new Vector3(transPos.x, transPos.y, 0);
    }

    void MoveToDest()
    {
        target.transform.position = mousePos;
        //transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * 10f);
    }

}
