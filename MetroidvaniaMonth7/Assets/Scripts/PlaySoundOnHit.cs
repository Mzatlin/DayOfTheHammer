using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string hitPath;

    IHittable hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<IHittable>();
        hit.OnHit += HandleHit;
    }

    void HandleHit()
    {
        FMODUnity.RuntimeManager.PlayOneShot(hitPath, transform.position);
    }

}
