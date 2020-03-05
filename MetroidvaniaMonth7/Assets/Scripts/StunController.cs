using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : MonoBehaviour, IStunnable
{
    public event Action OnEndStun = delegate { };
    public event Action OnStun = delegate { };

    [SerializeField]
    float stunDuration = 2f;
    [SerializeField]
    bool isStunned = false;
    ILift lift;

    public bool IsStunned { get => isStunned; set => isStunned = value; }

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
        OnStun();
        yield return new WaitForSeconds(time);
        OnEndStun();
        isStunned = false;
    }
}
