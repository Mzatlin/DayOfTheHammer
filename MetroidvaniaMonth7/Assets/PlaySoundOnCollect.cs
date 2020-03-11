using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollect : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string collectSound;
    ICollectable collect;
    // Start is called before the first frame update
    void Start()
    {
        collect = GetComponent<ICollectable>();
        collect.OnCollect += HandleCollect;
    }

    private void HandleCollect()
    {
        FMODUnity.RuntimeManager.PlayOneShot(collectSound, transform.position);
    }

}
