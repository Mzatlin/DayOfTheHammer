using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoardController : MonoBehaviour
{
    IFade fade;
    [SerializeField]
    Canvas storyBoardCanvas;
    [SerializeField]
    float fadeDuration;
    [SerializeField]
    float transitionTime = 3f;
    Image currentStoryBoard;
    [SerializeField]
    List<GameObject> storyBoards = new List<GameObject>();
    [SerializeField]
    List<int> storyBoardTimers = new List<int>();
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (storyBoardCanvas != null)
        {
            currentStoryBoard = storyBoardCanvas.GetComponentInChildren<Image>();
        }
        fade = GetComponent<IFade>();
        BeginningFadeOut();
        StartCoroutine(InitialStart());
    }

    void BeginningFadeOut()
    {
        if (fade != null)
        {
            fade.Fade(0f, 0.001f);
        }
    }

    void SetSprite(Sprite sprite)
    {
        currentStoryBoard.sprite = sprite;
    }

    IEnumerator InitialStart()
    {
        yield return new WaitForSeconds(transitionTime);
        StartCoroutine(StoryboardDelay());
    }

    IEnumerator StoryboardDelay()
    {

        foreach (GameObject obj in storyBoards)
        {
            SetSprite(obj.GetComponent<SpriteRenderer>().sprite);
            fade.Fade(1f, fadeDuration);
            yield return new WaitForSeconds(storyBoardTimers[index]);
            fade.Fade(0f, fadeDuration);
            yield return new WaitForSeconds(storyBoardTimers[index]/2);
            index++;
        }

    }

}
