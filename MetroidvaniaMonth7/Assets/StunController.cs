using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : StunBase
{
    public event Action OnEndStun = delegate { };
    [SerializeField]
    float stunDuration = 2f;
    ILift lift;
    // Start is called before the first frame update
    void Start()
    {
        lift = GetComponent<ILift>();
        lift.OnLift += HandleLift;
    }

    private void HandleLift(float obj)
    {
        if (isStunned)
            return;

        StartCoroutine(StunTime(stunDuration+1/obj));
    }


    IEnumerator StunTime(float time)
    {
        isStunned = true;
        base.ProcessStun();
        yield return new WaitForSeconds(time);
        OnEndStun();
        isStunned = false;
    }
}
