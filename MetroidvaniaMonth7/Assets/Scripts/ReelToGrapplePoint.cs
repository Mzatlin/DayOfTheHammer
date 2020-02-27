using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelToGrapplePoint : MonoBehaviour
{
    [SerializeField]
    GameObject hammer;
    bool isGrappled = false;
    Transform hook; 
    // Start is called before the first frame update
    void Start()
    {
        hammer.GetComponent<GrappleOnTouch>().OnGrapple += HandleTouch;
    }

    private void HandleTouch(Transform obj)
    {
        // while(transform.position != obj.position)
        //    {
      //  isGrappled = true;
     //   hook = obj;
  
        //   }
     transform.position = obj.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        //reelback logic
      //  if (isGrappled && hook != null)
      //  {
       //     transform.position = Vector2.Lerp(transform.position, hook.position, Time.time);
      //  }

    }
}
