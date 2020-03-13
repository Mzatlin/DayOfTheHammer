using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnStart : MonoBehaviour
{
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;
    [SerializeField]
    float delayTime = 0f;
    IFade fade;

    void Start()
    {
        fade = GetComponent<IFade>();
        if (fade != null)
        {
            StartCoroutine(FadeDelay());
        }
        else
        {
            Debug.Log("Fade cannot be found");
        }
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(delayTime);
        fade.Fade(fadeAlpha, fadeDuration);
    }

}
