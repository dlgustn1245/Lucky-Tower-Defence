using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    private Camera cam;
    
    //클릭된 오브젝트
    private GameObject target;

    private bool selected = false;
    private bool clicked = false;

    public GameObject[] towers;

    private Vector2 mousePos, transPos, destPos;

    private Vector2 touchPos;

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
            touchPos = cam.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(touchPos);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, cam.transform.forward);

            if (hit.collider != null)
            {
                target = hit.collider.gameObject;
                Debug.Log(target);

                selected = true;
            }
        }
        //왼쪽 버튼
        if (Input.GetMouseButtonDown(0) && selected)
        {
            CalDestPos();
            clicked = true;
        }

        if (clicked == true)
        {
            target.transform.position = Vector2.MoveTowards(target.transform.position, destPos, Time.deltaTime * 10f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            selected = false;
            clicked = false;
        }
    }

    void CalDestPos()
    {
        mousePos = Input.mousePosition;
        transPos = cam.ScreenToWorldPoint(mousePos);
        destPos = new Vector2(transPos.x, transPos.y);
    }
}
