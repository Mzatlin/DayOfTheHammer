using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    LayerMask interactionLayer;
    [SerializeField]
    PlayerStateSO playerState;
    Ray2D ray;
    ICharacterMovement charMove;
    IInteractable interact;
    [SerializeField]
    float interactionRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        charMove = GetComponent<ICharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray2D(transform.position, charMove.GetCurrentMoveDirection());
        Debug.DrawRay(ray.origin, ray.direction, Color.green, interactionRange);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, interactionRange, interactionLayer);
        if (hit != false && playerState.IsPlayerReady())
        {
           interact = hit.transform.GetComponent<IInteractable>();
            if(interact != null)
            {
                interact.ProcessHover();
                interact.IsInteracting = true;
                if (Input.GetKeyDown(KeyCode.S))
                {
                    interact.IsInteracting = false;
                    interact.ProcessInteraction();
                    interact.ProcessHoverLeave();
                }
            }
     
        }
        else
        {
            interact.IsInteracting = false;
        }
    }
}
