using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{

    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask finalLayerMask;
    IMove move;
    private bool isHitting;
    public Vector2 lastDirection;
    Vector2 directionCurrent;

    // RaycastHit2D hit;
    Ray2D ray;
    // Start is called before the first frame update
    void Start()
    {
        lastDirection = transform.right;
        move = GetComponent<IMove>();
    }
     
    // Update is called once per frame
    void Update()
    {
        if (move.MoveDirection == Vector2.zero)
        {
            directionCurrent = lastDirection;
        }
        else
        {
            directionCurrent = move.MoveDirection;
            lastDirection = directionCurrent;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryHit();

            //implement hammer attack sound
            FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Hammer-Attack");

        }
    }

    void TryHit()
    {
        ray = new Ray2D(transform.position, directionCurrent);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, checkRadius);
        var hit = Physics2D.RaycastAll(ray.origin, ray.direction, checkRadius, finalLayerMask);
        foreach (var obj in hit)
        {
            var hittable = obj.collider.transform.GetComponent<IHittable>();
            if (hittable != null)
            {
                hittable.ProcessHit();
            }
        }
    }
}
