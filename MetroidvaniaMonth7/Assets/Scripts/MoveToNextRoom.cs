using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNextRoom : MonoBehaviour
{
    [SerializeField]
    Transform NextDoor;
    // Start is called before the first frame update
    void Start()
    {
        if(NextDoor == null)
        {
            Debug.Log("No Door Assigned!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = NextDoor.transform.position;
    }
}
