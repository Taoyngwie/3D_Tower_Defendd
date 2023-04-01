using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower theTower;

    public UpgradeState[] RangeUpgrade;
    public int currentRangeUpgrade;
    public bool hasRangeUpgrade = true;

    public UpgradeState[] firerateUpgrades;
    public int currentFireRateUpgrade;
    public bool hasFirerateUpgrade = true;
    [TextArea]
    public string fireRateText;
    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        theTower.range = RangeUpgrade[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
        if(currentRangeUpgrade >= RangeUpgrade.Length)
        {
            hasRangeUpgrade = false;
        }
    }

    public void UpgradeFireRate()
    {
        theTower.fireRate = firerateUpgrades[currentFireRateUpgrade].amount;
        currentFireRateUpgrade++;
        if(currentFireRateUpgrade >= firerateUpgrades.Length) 
        {
            hasFirerateUpgrade = false;
        }
    }
}

[System.Serializable]
public class UpgradeState 
{
    public float amount;
    public int cost;
}
