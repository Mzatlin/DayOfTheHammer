using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCharge : MonoBehaviour
{
    IAbility charge;
    [SerializeField]
    PlayerStateSO playerState;
    // Start is called before the first frame update
    void Start()
    {
        charge = GetComponent<IAbility>();
        charge.OnAbilityStart += HandleChargeBegin;
        charge.OnAbilityEnd += HandleChargeEnd;
    }

    private void HandleChargeEnd()
    {
        playerState.isStopped = false;
    }

    private void HandleChargeBegin()
    {
        playerState.isStopped = true;
    }

}
