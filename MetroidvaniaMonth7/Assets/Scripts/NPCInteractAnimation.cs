using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractAnimation : MonoBehaviour
{
    IInteractable interact;
    IDialogEnd dialog;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        dialog = GetComponent<IDialogEnd>();
        dialog.OnDialogEnd += HandleEnd;
        interact = GetComponent<IInteractable>();
        interact.OnInteract += HandleInteraction;
    }

    private void HandleEnd()
    {
        animator.SetBool("IsInteracting", false);
    }

    private void HandleInteraction()
    {
        animator.SetBool("IsInteracting", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.IsInteracting)
        {
            animator.SetBool("IsHovering", true);
        }
        else
        {
            animator.SetBool("IsHovering", false);
        }
    }
}
