using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoving : MonoBehaviour
{
    public Camera cam;
    
    //클릭된 오브젝트
    public TowerController_Test target;

    bool selected;

    Vector2 mousePos, transPos;
    Vector2 touchPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTower();
        }
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target.destination = CalDestPos();
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

		if (hit.collider && hit.collider.gameObject.CompareTag("Tower"))
		{
			target = hit.collider.gameObject.GetComponent<TowerController_Test>();
			selected = true;
		}

  //       if (hit.transform.CompareTag("Tower"))
		// {
		// 	target = hit.transform.GetComponent<TowerController>();
		// 	selected = true;
		// }
    }

    Vector2 CalDestPos()
    {
        mousePos = Input.mousePosition;
        transPos = cam.ScreenToWorldPoint(mousePos);
        return new Vector2(transPos.x, transPos.y);
    }
}