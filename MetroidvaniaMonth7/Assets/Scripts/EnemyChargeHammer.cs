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
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRelease())
        {
            animator.SetBool("CanRelease", true);
            DropHammer();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Piston", GetComponent<Transform>().position);

        }

        holdDownTime += Time.deltaTime;
    }

    void DropHammer()
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
        StartCoroutine(ReleaseDelay());
    }



    IEnumerator ReleaseDelay()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("CanRelease", false);
    }
}
