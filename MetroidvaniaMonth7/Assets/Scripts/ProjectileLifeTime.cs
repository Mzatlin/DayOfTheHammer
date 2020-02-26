using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTime : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 3f;
    [SerializeField]
    LayerMask finalLayerMask;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if((1 << collision.gameObject.layer & finalLayerMask) != 0)
        {
            Destroy(gameObject);
        }
 
    }
}
