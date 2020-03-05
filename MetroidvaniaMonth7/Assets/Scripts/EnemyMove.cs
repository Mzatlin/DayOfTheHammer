using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    IMove move;
    float nextJump = 0.3f;
    Vector2 enemyScale;
    bool isFacingRight;
    EnemyJump jump; //need to add isGrounded to Jump Interface 
    IStunnable stun;
    // Start is called before the first frame update
    void Start()
    {
        stun = GetComponent<IStunnable>();
        jump = GetComponent<EnemyJump>();
        enemyScale = transform.localScale;
        move = GetComponent<IMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!stun.IsStunned && jump.isGrounded)
        {
            move.MoveX(2f*nextJump);
            if (nextJump < 0.0f && isFacingRight == false)
            {
                FlipSprite();
            }
            else if (nextJump > 0.0f && isFacingRight == true)
            {
                FlipSprite();
            }
        }
        else
        {
            nextJump = Random.Range(-1f, 1f);
        }


    }
    void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}
