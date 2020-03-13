using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBoardController : MonoBehaviour
{
    IFade fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<IFade>();
        if(fade != null)
        {
            fade.Fade(0f, 0.001f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
