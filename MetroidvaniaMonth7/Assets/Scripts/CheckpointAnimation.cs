using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnimation : MonoBehaviour
{
    Animator animate;
    IInteractable interact;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractable>();
        interact.OnInteract += HandleInteract;
        animate = GetComponentInChildren<Animator>();
    }

    private void HandleInteract()
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(SuccessTime());
        }
    }

    IEnumerator SuccessTime()
    {
        animate.SetBool("IsSaving", true);
        yield return new WaitForSeconds(2f);
        isActive = false;
        animate.SetBool("IsSaving", false);
    }

}
