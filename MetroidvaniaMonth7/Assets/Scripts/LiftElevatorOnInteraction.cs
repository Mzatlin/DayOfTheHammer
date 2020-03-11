using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiftElevatorOnInteraction : MonoBehaviour, IElevatorStart
{
    public event Action OnElevatorStart = delegate { };
    ISetParent parent;
    IInteractable interact;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractable>();
        interact.OnInteract += HandleInteract;
        parent = GetComponentInParent<ISetParent>();
    }

    private void HandleInteract()
    {
        if (parent.IsParented)
        {
            OnElevatorStart();   
        }
    }


}
