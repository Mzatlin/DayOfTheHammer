using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnClick : OnClickListenerBase
{
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;
    IFade fade;

    void Start()
    {
        fade = GetComponent<IFade>();
    }
    public override void HandleClickEvent()
    {
        fade.Fade(fadeAlpha, fadeDuration);
    }
}
