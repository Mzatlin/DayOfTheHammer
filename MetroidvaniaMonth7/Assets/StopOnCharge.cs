using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCharge : MonoBehaviour
{
    IChargeable charge;
    // Start is called before the first frame update
    void Start()
    {
        charge = GetComponent<IChargeable>();
        charge.OnChargeBegin += HandleChargeBegin;
    }

    private void HandleChargeBegin()
    {
        Debug.Log("Working");
    }

}
