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

    Tower currentTower;
    TowerData currentTower_data;

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
        //����ؾ��ϴ� Ÿ�� ������ �޾ƿͼ� ����
        currentTower = cTower.GetComponent<TowerController>().tower;
        //Ÿ�� ���� Panel On
        gameObject.SetActive(true);
        //Ÿ�� ������ ����
        UpdateTowerData();
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }

    void UpdateTowerData()
	{
        //textGold.text = "" + playerGold.CurrentGold;
        textName.text = "" + currentTower.towerName;
        textDamage.text = "Damage: " + currentTower.damage;
        textRate.text = "Rate: " + currentTower.attackSpeed;
        textRange.text = "Range: " + currentTower.range;
    }
}
