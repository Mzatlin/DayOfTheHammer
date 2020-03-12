using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    Transform laserHit;
    [SerializeField]
    LayerMask laserMask;
    LineRenderer laserRenderer;
    RaycastHit2D hit;
    bool laserOn = true;
    IHittable hittable;



    // Start is called before the first frame update
    void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
        laserRenderer.useWorldSpace = true;
        laserRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFireLaser())
        {
            laserRenderer.enabled = true;
            FireLaser();
        }
        else
        {
            laserRenderer.enabled = false;
        }
    }

    void FireLaser()
    {
        Ray2D ray = new Ray2D(transform.position, -transform.up);
        RaycastHit2D hit;

        laserRenderer.SetPosition(0, ray.origin);

        hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);

        if (hit.collider)
        {
            laserRenderer.SetPosition(1, hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();

            if (hittable != null)
            {
                //       hittable.ProcessHit(2f);
            }
            laserRenderer.SetPosition(1, hit.point);
        }
        else
        {
            laserRenderer.SetPosition(1, ray.GetPoint(100f));
        }
          

}
bool CanFireLaser()
{
    return true;
}

}
