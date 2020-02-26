using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelToGrapplePoint : MonoBehaviour
{
    [SerializeField]
    GameObject hammer;
    // Start is called before the first frame update
    void Start()
    {
        hammer.GetComponent<GrappleOnTouch>().OnGrapple += HandleTouch;
    }

    private void HandleTouch(Transform obj)
    {
        transform.position = obj.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        //reelback logic
    }
}
