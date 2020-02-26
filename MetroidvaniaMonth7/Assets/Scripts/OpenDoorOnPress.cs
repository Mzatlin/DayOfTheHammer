using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnPress : MonoBehaviour
{

    [SerializeField]
    GameObject door;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = door.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsOpen", false);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsOpen", true);
    }
}
