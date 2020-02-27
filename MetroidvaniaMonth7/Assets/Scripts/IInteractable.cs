using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInteractable 
{
    event Action OnHover;
    event Action OnHoverLeave;
    event Action OnInteract;
    void ProcessInteraction();
    void ProcessHover();
    void ProcessHoverLeave();
    bool IsInteracting { get; set; }
}
