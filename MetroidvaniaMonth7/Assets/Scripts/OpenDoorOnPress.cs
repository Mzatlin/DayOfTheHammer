using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnPress : MonoBehaviour
{

    [SerializeField]
    GameObject door;
    Animator animator;
    Collider2D doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = door.GetComponent<Animator>();
        doorCollider = door.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsOpen", false);
        doorCollider.enabled = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsOpen", true);
        doorCollider.enabled = true;
    }
}
