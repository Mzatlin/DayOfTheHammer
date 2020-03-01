using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LiftPhysicsController : MonoBehaviour
{
    [SerializeField]
    float liftMultiplier = 1f;
    ILift lift;
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        lift = GetComponent<ILift>();
        lift.OnLift += HandleLift;
        rb = GetComponent<Rigidbody2D>();
    }

    private void HandleLift(float force)
    {
        rb.AddForce(new Vector2(0, force*liftMultiplier), ForceMode2D.Impulse);
    }

}
