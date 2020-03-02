using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractAnimation : MonoBehaviour
{
    IInteractable interact;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        interact = GetComponent<IInteractable>();
        interact.OnInteract += HandleInteraction;
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
