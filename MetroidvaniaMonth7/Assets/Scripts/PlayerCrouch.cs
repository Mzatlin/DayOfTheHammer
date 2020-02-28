using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField]
    LayerMask platformMask;
    IGrounded ground;
    Collider2D collider;
    [SerializeField]
    bool isStanding = false;
    [SerializeField]
    GameObject groundCheck;
    [SerializeField]
    RaycastHit2D down;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<IGrounded>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Physics2D.OverlapCircle(groundCheck.transform.position, 0.3f, platformMask))
        {
           // if (isStanding)
         //   {
              StartCoroutine(FallDelay());
        //    }

        }
            
    }


    IEnumerator FallDelay()
    {
        collider.isTrigger = true;
        yield return new WaitForSeconds(0.3f);
        collider.isTrigger = false;
        isStanding = false;
    }

}
