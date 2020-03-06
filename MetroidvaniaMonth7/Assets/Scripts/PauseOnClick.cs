using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseOnClick : MonoBehaviour
{
    public event Action OnResume = delegate { };

    // Update is called once per frame
    public void OnClickResume()
    {
        OnResume();
    }
}
