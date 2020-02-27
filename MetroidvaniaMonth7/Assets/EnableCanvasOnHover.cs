using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableCanvasOnHover : MonoBehaviour
{
    [SerializeField]
    Canvas hoverDescCanvas;
    [SerializeField]
    float canvasOffset;
    IInteractable interact;
    Vector2 canvasPosition;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        interact = GetComponent<IInteractable>();
        if(hoverDescCanvas != null)
        {
            hoverDescCanvas.enabled = false;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (interact.IsInteracting)
        {
            hoverDescCanvas.enabled = true;
        }
        else
        {
            hoverDescCanvas.enabled = false;
        }
        canvasPosition = camera.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + canvasOffset));
        hoverDescCanvas.transform.position = canvasPosition;
    }
}
