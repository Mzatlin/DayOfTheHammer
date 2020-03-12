using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemySound : MonoBehaviour
{
    // Start is called before the first frame update
   private void SpringJump ()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Spring", GetComponent <Transform> ().position);

    }
    private void SpringResting ()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Resting", GetComponent<Transform>().position);

    }
}
