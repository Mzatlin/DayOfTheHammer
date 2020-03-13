using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
   void FootstepSound ()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Footsteps", GetComponent<Transform>().position);

    }
}
