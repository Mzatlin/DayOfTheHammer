using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLiftController : MonoBehaviour, IElevatorEnd
{

    public event Action OnElevatorEnd = delegate { };
    [SerializeField]
    Transform currentSpot;
    [SerializeField]
    Transform destinationSpot;
    [SerializeField]
    float elevatorLiftSpeed = 1f;
    IElevatorStart start;
    bool isLifting;
    bool audioStatus=false;

    FMOD.Studio.EventInstance ElevatorSound;


    // Start is called before the first frame update
    void Start()
    {
        start = GetComponentInChildren<IElevatorStart>();
        start.OnElevatorStart += HandleElevatorStart;
        ElevatorSound = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiences/Elevator");
    }

    private void HandleElevatorStart()
    {
        isLifting = true;
        audioStatus = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLifting && (Vector2.Distance(transform.position, destinationSpot.position) > 1f))
        {
            transform.position = Vector2.Lerp(transform.position, destinationSpot.position, elevatorLiftSpeed);
            if (audioStatus)
            {
                ElevatorSound.start();
                audioStatus = false;
            }
        }
        if (isLifting == false)
        {
            ElevatorSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
           // Debug.Log("Elevator Stopped");
        }

    }
}
