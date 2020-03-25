using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SetTextActiveOnElevator : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textContent;
    [SerializeField]
    Canvas canvas;
    IElevatorStart start;
    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<IElevatorStart>();
        start.OnElevatorStart += HandleStart;
        canvas.enabled = false;
    }

    private void HandleStart()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        canvas.enabled = true;
    }
}


