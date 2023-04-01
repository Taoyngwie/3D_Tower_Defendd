using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject rangeButton, fireRateButton;
    public TextMeshProUGUI rangeText, fireRateText;

    public void SetupPanel()
    {
        if (TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            rangeText.text = "Upgrade Range (" + upgrader.RangeUpgrade[upgrader.currentRangeUpgrade].cost +"G)";

            rangeButton.SetActive(true);
        }
        else 
        {
            rangeButton.SetActive(false);
        }

        if (TowerManager.instance.selectedTower.upgrader.hasFirerateUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            fireRateText.text = upgrader.fireRateText + "(" + upgrader.firerateUpgrades[upgrader.currentFireRateUpgrade].cost + "G)";

            fireRateButton.SetActive(true);
        }
        else
        {
            fireRateButton.SetActive(false);
        }
    }

    public void RemoveTower()
    {
        MoneyManager.instance.SpendMoney(-50);
        Destroy(TowerManager.instance.selectedTower.gameObject);
        UIController.instance.CloseTowerUpgradePanel();
    }

    public void UpgradeRange()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasRangeUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.RangeUpgrade[upgrader.currentRangeUpgrade].cost))
            {
                upgrader.UpgradeRange();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);
            }
            else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }

    public void UpgradeFireRate()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasFirerateUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.firerateUpgrades[upgrader.currentFireRateUpgrade].cost))
            {
                upgrader.UpgradeFireRate();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);
            }
            else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }
}
