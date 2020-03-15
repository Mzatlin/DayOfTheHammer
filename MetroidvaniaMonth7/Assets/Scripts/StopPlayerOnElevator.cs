using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerOnElevator : MonoBehaviour
{
    [SerializeField]
    PlayerStateSO player;
    IElevatorStart start;
    IElevatorEnd end;
    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<IElevatorStart>();
        start.OnElevatorStart += HandleStart;
        end = GetComponent<IElevatorEnd>();
        end.OnElevatorEnd += HandleEnd;
    }

    private void HandleEnd()
    {
        player.isStopped = false;
    }

    private void HandleStart()
    {
        player.isStopped = true;
    }


}
