using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnHit : MonoBehaviour
{
    [SerializeField]
    Color flashColor;
    Color originalColor;
    SpriteRenderer sprite;
    IHittable hit;
    
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<IHittable>();
        hit.OnHit += HandleHit;
        sprite = GetComponentInChildren<SpriteRenderer>();
        originalColor = sprite.color;
    }

    private void HandleHit()
    {
        StartCoroutine(FlashDelay());
    }

    IEnumerator FlashDelay()
    {
        sprite.color = flashColor;
        yield return new WaitForSeconds(.1f);
        sprite.color = originalColor;
    }
}
