using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTime : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 3f;
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
}
