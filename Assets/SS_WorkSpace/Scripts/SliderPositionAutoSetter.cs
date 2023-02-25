using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 20.0f;
    private Transform targetTranform;
    private RectTransform rectTransform;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void Setup(Transform target)
    {
        // ü�¹ٰ� ����ٴ� Ÿ�� ����
        targetTranform = target;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if(targetTranform == null)
        {
            Destroy(gameObject);
            return;
        }
        // ���� ��ǥ�� �������� ȭ�鿡���� ��ǥ ���� ����
        Vector3 screenPosition = cam.WorldToScreenPoint(targetTranform.position);
        rectTransform.position = screenPosition + distance;
    }
}
