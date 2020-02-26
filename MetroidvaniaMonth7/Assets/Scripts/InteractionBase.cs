using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour, IInteractable
{
    public event Action OnHover = delegate { };
    public event Action OnInteract = delegate { };
    public event Action OnHoverLeave = delegate { };

    public void ProcessHover()
    {
        OnHover();
    }

    public void ProcessInteraction()
    {
        OnInteract();
    }

    public void ProcessHoverLeave()
    {
        OnHoverLeave();
    }
}
