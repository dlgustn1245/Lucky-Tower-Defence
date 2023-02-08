using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDataViewer : MonoBehaviour
{
    /*[SerializeField]
    private TextMeshProUGUI textGold;*/
    /*[SerializeField]
    private Image imageTower;*/
    [SerializeField]
    private Text textName;
    [SerializeField]
    private Text textDamage;
    [SerializeField]
    private Text textRate;
    [SerializeField]
    private Text textRange;
    [SerializeField]
    private Text textLevel;

    private TowerData currentTower;
    private PlayerGold playerGold;

    // Start is called before the first frame update
    void Start()
    {
        OffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform cTower)
    {
        //출력해야하는 타워 정보를 받아와서 저장
        currentTower = cTower.GetComponent<TowerData>();
        //타워 정보 Panel On
        gameObject.SetActive(true);
        //타워 정보를 갱신
        UpdateTowerData();
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }

    void UpdateTowerData()
	{
        //textGold.text = "" + playerGold.CurrentGold;
        textName.text = "" + currentTower.TowerName;
        textDamage.text = "Damage: " + currentTower.Damage;
        textRate.text = "Rate: " + currentTower.Rate;
        textRange.text = "Range: " + currentTower.Range;
        textLevel.text = "Level: " + currentTower.Level;
    }
}
