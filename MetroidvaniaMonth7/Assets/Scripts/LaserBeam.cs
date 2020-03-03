using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    Transform laserHit;
    LineRenderer laserRenderer;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
        //    laserRenderer.useWorldSpace = true;
        laserRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFireLaser())
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        Ray2D ray = new Ray2D(transform.position, transform.up);
        laserRenderer.SetPosition(0, transform.position);
        hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit.collider)
        {
            Debug.Log("Hit");
            //   laserRenderer.SetPosition(1, new Vector3(hit.point.x, hit.point.y, transform.position.z));
            laserRenderer.SetPosition(1, hit.point);
        }
        else
        {
            laserRenderer.SetPosition(1, transform.position * 2000);
        }
        //   Debug.DrawLine(transform.position, hit.point);
        //    laserHit.position = hit.point;
        //   laserRenderer.SetPosition(0, transform.position);
        //    laserRenderer.SetPosition(1, laserHit.position);
    }
    bool CanFireLaser()
    {
        return true;
    }
}
