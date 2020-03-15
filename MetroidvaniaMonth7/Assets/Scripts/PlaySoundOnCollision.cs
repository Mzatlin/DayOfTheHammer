using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string collisionPath;
    [SerializeField]
    LayerMask soundMask;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & soundMask) != 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(collisionPath, transform.position);
        }
    }
}
