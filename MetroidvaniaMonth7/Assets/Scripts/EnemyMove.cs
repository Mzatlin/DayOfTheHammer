using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    IMove move;
    float nextJump;
    EnemyJump jump; //need to add isGrounded to Jump Interface 
    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<EnemyJump>();
        move = GetComponent<IMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump.isGrounded)
        {
            move.MoveX(0.3f);
        }
        nextJump = Random.Range(-0.3f, 0.3f);

    }
}
