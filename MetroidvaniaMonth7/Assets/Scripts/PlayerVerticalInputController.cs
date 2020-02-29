 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerticalInputController : MonoBehaviour, IVerticalDirection
{
    [SerializeField]
    PlayerStateSO playerState;
    float moveY;
    Vector2 moveDirectionY;

    public Vector2 MoveDirectionY { get => moveDirectionY; set => moveDirectionY = value; }

    // Update is called once per frame
    void Update()
    {
        if (playerState.IsPlayerReady())
        {
           moveY = Input.GetAxisRaw("Vertical");
           moveDirectionY = new Vector2(0, moveY);
           
        }
    }
}
