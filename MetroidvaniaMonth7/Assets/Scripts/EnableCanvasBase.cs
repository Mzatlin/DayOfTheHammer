using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvasBase : MonoBehaviour, ICanvas
{
    [SerializeField]
    Canvas canvas;
    // Start is called before the first frame update

    public void SetCanvasActive()
    {
        if (canvas != null)
        {
            canvas.enabled = true;
        }
    }

    public void SetCanvasInactive()
    {
        if (canvas != null)
        {
            canvas.enabled = false;
        }
    }


}
