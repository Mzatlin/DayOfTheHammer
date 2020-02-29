using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerticalInputController : MonoBehaviour, IVerticalDirection
{
    [SerializeField]
    PlayerStateSO playerState;

    public Vector2 MoveDirectionY { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.IsPlayerReady())
        {

        }
    }
}
