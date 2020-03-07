using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderToHammer : MonoBehaviour
{
    [SerializeField]
    GameObject hammer;
    LineRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<LineRenderer>();
        render.useWorldSpace = true;
        render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hammer != null && hammer.activeInHierarchy)
        {
            RenderToHammer();
        }
        else
        {
            render.enabled = false;
        }
    }

    void RenderToHammer()
    {
        render.enabled = true;
        render.SetPosition(0, transform.position);
        render.SetPosition(1, hammer.transform.position);

    }
}
