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
    Transform hook;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        hammer.GetComponent<GrappleOnTouch>().OnGrapple += HandleTouch;
    }

    private void HandleTouch(Transform obj)
    {
        isGrappled = true;
        hook = obj;
        hammer.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //reelback logic
        if (isGrappled && hook != null && (Vector2.Distance(transform.position,hook.position) > 1f))
        {
            transform.position = Vector2.Lerp(transform.position, hook.position,grappleSpeed);
        }
        else
        {

            isGrappled = false;

        }

    }
}
