using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
 private void PistonHit ()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Piston", GetComponent<Transform>().position);

    }

    private void DoorOpen ()
    {
       // FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Door-Open", GetComponent<Transform>().position);

    }

    private void DoorClose()
    {
       // FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Door-Close", GetComponent<Transform>().position);

    }
}
