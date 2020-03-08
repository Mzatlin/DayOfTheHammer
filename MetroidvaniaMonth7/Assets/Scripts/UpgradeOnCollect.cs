using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOnCollect : CollectBase
{
    [SerializeField]
    PlayerStatsSO playerStats;
    [SerializeField]
    UpgradeSO upgrade;
    [SerializeField]
    float upgradeDifference = 1f;
    // Start is called before the first frame update

    protected override void HandleCollection()
    {
        base.HandleCollection();
        upgrade.upgradeAmount += upgradeDifference;
        gameObject.SetActive(false);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Ability-Collected");
    }

}
