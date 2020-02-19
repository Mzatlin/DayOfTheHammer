using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeHammerAttack : MonoBehaviour, IChargeAttack
{
    [SerializeField]
    Transform chargeCenter;
    [HideInInspector]
    public float chargeRadius;
    public LayerMask Enemy;
    public LayerMask Box;
    LayerMask finalLayerMask;
    bool isHit;
    List<Collider2D> results = new List<Collider2D>();

    public float HammerRadius { get => chargeRadius; set => chargeRadius = value; }

    // Start is called before the first frame update

    public void InitializeCharge()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Box") | (1 << LayerMask.NameToLayer("Enemy")));
    }


    //This Tick method is called in the use ability function once per frame
    public void HammerChargeTick()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // add charging sound here
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hammer_Charge");


            var results = Physics2D.OverlapCircleAll(chargeCenter.position, chargeRadius, finalLayerMask);
            foreach (Collider2D obj in results)
            {
                float distance = Vector3.Distance(obj.transform.position, transform.position);
                if (distance < chargeRadius)
                {
                    if (distance < 1.5f)
                    {
                        obj.gameObject.SetActive(false);
                        //should I make a special sound for gameobjects destroyed by the hammer charge here?
                        //FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Destroyed_By_Charge");

                    }

                    obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 35f / distance), ForceMode2D.Impulse);

                    //I'm guessing this throws objects that aren't within 1.5 but within the charge radius. Could maybe add a sound to this.

                }
            }
        }
    }
}
