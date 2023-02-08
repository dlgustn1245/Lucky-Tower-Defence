using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    public Camera cam;
    
    //클릭된 오브젝트
    TowerController target;

    bool selected;

    Vector2 mousePos, transPos, destPos;
    Vector2 touchPos;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTower();
        }
        if (Input.GetMouseButtonDown(1) && selected)
        {
            CalDestPos();
            target.destination = destPos;
            target.isClicked = true;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            selected = false;
            target.isClicked = false;
        }
    }

    void SelectTower()
    {
        touchPos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, cam.transform.forward);
    
        if (hit.collider)
        {
            target = hit.collider.gameObject.GetComponent<TowerController>();
            selected = true;
        }
    }

    void CalDestPos()
    {
        mousePos = Input.mousePosition;
        transPos = cam.ScreenToWorldPoint(mousePos);
        destPos = new Vector2(transPos.x, transPos.y);
    }
}
