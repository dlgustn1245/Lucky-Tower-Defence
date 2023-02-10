using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
	private bool state = false;

	Tower currentTower;
	ClickToShowData info;

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
		currentTower = info.target.GetComponent<TowerController>().tower;

		if (currentTower.grade == TowerGrade.Common)
        {
			currentTower.attackSpeed++;
			currentTower.damage++;
			currentTower.range++;
        }
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

	}
}
