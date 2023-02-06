using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    Camera cam;
    
    //클릭된 오브젝트
    GameObject target;

    bool selected = false;
    bool clicked = false;

    Vector2 mousePos, transPos, destPos;
    Vector2 touchPos;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        if (Input.GetMouseButtonDown(1) && selected)
        {
            CalDestPos();
            clicked = true;
        }

        if (clicked)
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
