using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnFadeController : MonoBehaviour
{
    [SerializeField]
    Canvas canvasToShow;
    IFade fade;
    // Start is called before the first frame update
    void Start()
    {
        canvasToShow.enabled = false;
        fade = GetComponent<IFade>();
        fade.OnFade += HandleFade;
        fade.OnEndFade += HandleEndFade;
    }

    private void HandleEndFade()
    {
        canvasToShow.enabled = true;
    }

    private void HandleFade()
    {
        canvasToShow.enabled = false;
    }

}
