using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    // Text - TextMeshPro UI [플레이어의 골드]
    [SerializeField]
    private TextMeshProUGUI textPlayerGold;
    // 플레이어의 골드 정보
    [SerializeField]
    private PlayerGold playerGold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textPlayerGold.text = playerGold.CurrentGuld.ToString();
    }
}
