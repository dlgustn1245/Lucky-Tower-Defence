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
        // 체력바가 따라다닐 타겟 설정
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
        // 월드 좌표계 기준으로 화면에서의 좌표 값을 구함
        Vector3 screenPosition = cam.WorldToScreenPoint(targetTranform.position);
        rectTransform.position = screenPosition + distance;
    }
}
