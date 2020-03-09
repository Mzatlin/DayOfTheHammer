using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeHammerAttack : ChargeBase, IChargeAttack, IAbility
{
    public event Action OnAbilityStart = delegate { };
    public event Action OnAbilityEnd = delegate { };

    [SerializeField]
    PlayerStateSO playerState;
    [SerializeField]
    Transform chargeCenter;
    [HideInInspector]
    public float chargeRadius;
    List<Collider2D> results = new List<Collider2D>();
    bool isAbilityInUse = false;
    Animator animator;

    public float HammerRadius { get => chargeRadius; set => chargeRadius = value; }

    public bool IsAbilityInUse => isAbilityInUse;

    bool IAbility.IsAbilityInUse { get => isAbilityInUse; set => isAbilityInUse = value; }

    // Start is called before the first frame update

    public void InitializeCharge()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Box") | (1 << LayerMask.NameToLayer("Enemy")));
        animator = GetComponentInChildren<Animator>();
    }

    //This Tick method is called in the use ability function once per frame
    public void HammerChargeTick()
    {

        if (Input.GetKey(KeyCode.E))
        {
            if (isAbilityInUse || playerState.IsPlayerReady())
            {
                isAbilityInUse = true;
                holdDownTime += Time.deltaTime;
            }

        }
        if (holdDownTime > .2f)
        {
            // add charging sound here
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hammer_Charge");
            isAbilityInUse = true;
            OnAbilityStart();
        }

        if (CanRelease())
        {
 
            var results = Physics2D.OverlapCircleAll(chargeCenter.position, chargeRadius, finalLayerMask);
            if (results != null)
            {
                foreach (Collider2D obj in results)
                {
                    StartCoroutine(EffectDelay(obj));

                }
            }
        }

        animator.SetFloat("ChargePower", holdDownTime);

    }

    IEnumerator EffectDelay(Collider2D obj)
    {
        yield return new WaitForSeconds(0.1f);
        ProcessHammerCharge(obj);
        animator.SetBool("CanRelease", false);
        isAbilityInUse = false;
        OnAbilityEnd();

    }

    protected override bool CanRelease()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {

            if (holdDownTime > timeToCharge)
            {
                holdDownTime = 0f;
                animator.SetBool("CanRelease", true);
                return true;
            }
            else
            {
                isAbilityInUse = false;
                OnAbilityEnd();
                holdDownTime = 0f;
                animator.SetBool("CanRelease",false);
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    protected override void ProcessHammerCharge(Collider2D obj)
    {
        base.ProcessHammerCharge(obj);
        if (targetDistance < chargeRadius)
        {

            if (targetDistance < chargeRadius/5)
            {
                var hit = obj.GetComponent<IHittable>();
                if (hit != null)
                {
                    hit.ProcessHit(10f/targetDistance);
                }
                //should I make a special sound for gameobjects destroyed by the hammer charge here?
                //FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Destroyed_By_Charge");
            }
            var lift = obj.GetComponent<ILift>();
            if (lift != null)
            {
                lift.ProcessLift(35f / targetDistance);
            }


            //I'm guessing this throws objects that aren't within 1.5 but within the charge radius. Could maybe add a sound to this.
        }
    }


}
