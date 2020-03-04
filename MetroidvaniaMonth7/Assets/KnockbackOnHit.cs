using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockbackOnHit : MonoBehaviour, IMoveBlock
{
    Rigidbody2D rb;
    IHittable hit;
    Vector2 targetPoint;
    Vector2 blockPoint;
    [SerializeField]
    float moveXSpeed = 5f;

    public float MoveXSpeed { get => moveXSpeed; set => moveXSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hit = GetComponent<IHittable>();
        hit.OnHitTransform += HandleHit;
    }

    void HandleHit(Transform trans)
    {
        targetPoint = Vector2.right;
        blockPoint = trans.position - transform.position;
        if (Vector2.Dot(targetPoint, blockPoint) < 0)
        {
            rb.AddForce(new Vector2(moveXSpeed,0), ForceMode2D.Impulse);
        }
        if (Vector2.Dot(targetPoint, blockPoint) > 0)
        {
            rb.AddForce(new Vector2(-moveXSpeed, 0), ForceMode2D.Impulse);
        }
    }
}
