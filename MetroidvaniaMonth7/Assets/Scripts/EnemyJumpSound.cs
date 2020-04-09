using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpSound : MonoBehaviour
{
   

    private void SpringJump ()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/SpringJump", GetComponent <Transform> ().position);

    }

}
