using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
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
        move.MoveX(0.1f);
    }
}
