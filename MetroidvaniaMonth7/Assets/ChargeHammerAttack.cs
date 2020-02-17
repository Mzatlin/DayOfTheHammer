using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeHammerAttack : MonoBehaviour
{
    [SerializeField]
    Transform chargeCenter;
    [SerializeField]
    float chargeRadius;
    public LayerMask Enemy;
    public LayerMask Box;
    LayerMask finalLayerMask;
    bool isHit;
    List<Collider2D> results = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Box") | (1 << LayerMask.NameToLayer("Enemy")));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var results = Physics2D.OverlapCircleAll(chargeCenter.position, chargeRadius, finalLayerMask);
          //  Gizmos.DrawWireSphere(chargeCenter.position, chargeRadius);
            foreach(Collider2D obj in results)
            {
                float distance = Vector3.Distance(obj.transform.position, transform.position);
                if (distance < chargeRadius)
                {
                    if(distance < 1.5f)
                    {
                        obj.gameObject.SetActive(false);
                    }

                    obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 35f/distance),ForceMode2D.Impulse);
                }
            }
        }

    }
}
