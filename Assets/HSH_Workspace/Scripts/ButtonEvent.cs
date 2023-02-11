using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
	bool state = false;
	
	public ClickToShowData info;
	public GameManager gameManager;
	Tower currentTower;

	public void Start()
	{
		//currentTower = info.target.GetComponent<TowerController>().tower;
	}

    public void UpgradeButton()
    {
        if (state == false)
        {
			gameObject.SetActive(true);
			state = true;
        }
        else
        {
			gameObject.SetActive(false);
			state = false;
        }
    }

    public void UpgradeCommon()
	{
		// if (currentTower.grade == TowerGrade.Common)
  //       {
		// 	currentTower.attackSpeed++;
		// 	currentTower.damage++;
		// 	currentTower.range++;
  //       }
	}

	public void UpgradeUnCommon()
	{

	}

	public void UpgradeRare()
	{

	}

	public void UpgradeUnique()
	{

	}

	public void UpgradeEpic()
	{

	}

	public void UpgradeLegendary()
	{

	}
	public void SellTower()
	{
		GameManager.Instance.gold += currentTower.price;
		//Destroy(gameObject);
	}
}
