using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnElevator : MonoBehaviour
{
    IElevatorStart start;
    IFade fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<IFade>();
        start = GetComponent<IElevatorStart>();
        start.OnElevatorStart += HandleStart;
    }

    private void HandleStart()
    {
        fade.Fade(1, 4f);
    }

}
