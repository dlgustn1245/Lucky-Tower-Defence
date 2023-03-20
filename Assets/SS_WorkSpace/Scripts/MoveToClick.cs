using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private GameObject selectedObject;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("selected");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
            }
        }
        if (selectedObject != null && Input.GetMouseButton(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 moveDirection = targetPosition - selectedObject.transform.position;
            moveDirection.Normalize();

            float moveSpeed = 5.0f;
            selectedObject.GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;
        }
        if (selectedObject != null && Input.GetMouseButtonUp(1))
        {
            selectedObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
