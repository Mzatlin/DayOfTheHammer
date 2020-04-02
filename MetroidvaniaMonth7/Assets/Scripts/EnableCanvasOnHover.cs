using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EnableCanvasOnHover : MonoBehaviour
{
    [SerializeField]
    Canvas hoverDescCanvas;
    [SerializeField]
    TextMeshProUGUI textContent;
    [SerializeField]
    string text;
    [SerializeField]
    float canvasOffsetY = 1f;
    [SerializeField]
    float canvasOffsetX = -0.5f;
    [SerializeField]
    IInteractable interact;
    Vector2 canvasPosition;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        textContent = hoverDescCanvas.GetComponentInChildren<TextMeshProUGUI>();
        interact = GetComponent<IInteractable>();
        if (hoverDescCanvas != null)
        {
            Debug.Log("No Canvas Assigned.");
        }
        else
        {
            hoverDescCanvas.enabled = false;
        }

        interact.OnHover += HandleHover;
        interact.OnHoverLeave += HandleLeave;


    }

    private void HandleLeave()
    {
        hoverDescCanvas.enabled = false;
    }

    private void HandleHover()
    {
        if (interact.IsInteracting)
        {
            hoverDescCanvas.enabled = true;
            textContent.text = text;
            canvasPosition = camera.WorldToScreenPoint(new Vector2(transform.position.x+canvasOffsetX, transform.position.y + canvasOffsetY));
            textContent.transform.position = canvasPosition;
        }
    }
}
