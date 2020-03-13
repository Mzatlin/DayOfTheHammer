using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelToGrapplePoint : MonoBehaviour
{
    [SerializeField]
    GameObject hammer;
    [SerializeField]
    float grappleSpeed = 0.3f;
    bool isGrappled = false;
    bool grappleSoundStatus = false;
    IAbility ability;
    Transform hook;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ability = GetComponent<IAbility>();
        animator = GetComponentInChildren<Animator>();
        hammer.GetComponent<GrappleOnTouch>().OnGrapple += HandleTouch;
    }

    private void HandleTouch(Transform obj)
    {
        isGrappled = true;
        hook = obj;
        hammer.SetActive(false);
        animator.SetBool("IsThrowing", false);
    }


    // Update is called once per frame
    void Update()
    {
        //reelback logic
        if (isGrappled && hook != null)
        {
            if ((Vector2.Distance(transform.position, hook.position) > 1f))
            {
                transform.position = Vector2.Lerp(transform.position, hook.position, grappleSpeed);
                if (grappleSoundStatus != isGrappled)
                {
                    grappleSoundStatus = isGrappled;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Reel", GetComponent<Transform>().position);
                }

            }
            else if ((Vector2.Distance(transform.position, hook.position) < 1f))
            {
                StopGrapple();
            }
        }
    }

    void StopGrapple()
    {
        grappleSoundStatus = false;
        isGrappled = false;
    }
}
