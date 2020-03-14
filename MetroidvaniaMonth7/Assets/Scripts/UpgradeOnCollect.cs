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
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void HandleCollection()
    {
        base.HandleCollection();
        upgrade.upgradeAmount += upgradeDifference;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Ability-Collected");
        if (render != null)
        {
            render.enabled = false;
        }
    }

}
