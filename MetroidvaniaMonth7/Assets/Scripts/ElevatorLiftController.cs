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


    // Start is called before the first frame update
    void Start()
    {
        start = GetComponentInChildren<IElevatorStart>();
        start.OnElevatorStart += HandleElevatorStart;
    }

    private void HandleElevatorStart()
    {
        isLifting = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLifting && (Vector2.Distance(transform.position, destinationSpot.position) > 1f))
            transform.position = Vector2.Lerp(transform.position, destinationSpot.position, elevatorLiftSpeed);
    }
}
