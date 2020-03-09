using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeHammer : ChargeBase
{
    [SerializeField]
    Transform chargeCenter;
    [SerializeField]
    float chargeRadius = 1.5f;
    [SerializeField]
    float liftPower = 35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRelease())
        {
            var results = Physics2D.OverlapCircleAll(chargeCenter.position, chargeRadius, finalLayerMask);
            if (results != null)
            {
                foreach (Collider2D obj in results)
                {
                    ProcessHammerCharge(obj);
                }
            }
        }

        holdDownTime += Time.deltaTime;
    }

    protected override void ProcessHammerCharge(Collider2D obj)
    {
        base.ProcessHammerCharge(obj);
        if (targetDistance < chargeRadius)
        {

            if (targetDistance < chargeRadius / 5
                )
            {
                var hit = obj.GetComponent<IHittable>();
                if (hit != null)
                {
                    hit.ProcessHit(10f / targetDistance);
                }
            }
            var lift = obj.GetComponent<ILift>();
            if (lift != null)
            {
                lift.ProcessLift(liftPower / targetDistance);
            }
        }
    }
}
