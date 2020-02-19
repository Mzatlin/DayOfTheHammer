using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    IMove move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<IMove>();
    }

    // Update is called once per frame
    void Update()
    {
        move.MoveX(1);
    }
}
