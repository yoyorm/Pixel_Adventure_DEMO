using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private PlayerControl playerControl;
    public Animator animator;
    public bool OnGround =false;
    public bool disable = false;

    private void Start()
    {
        rb=player.GetComponent<Rigidbody2D>();
        playerControl=player.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        //地面检测
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.2f, ~(1<<3)))
        {
            OnGround = true;
            animator.SetBool("OnGround",OnGround);
        }
        else
        {
            OnGround = false;
            animator.SetBool("OnGround",OnGround);
        }
        //受伤动画
        
        animator.SetFloat("VelocityY",(rb.velocity.y));
        animator.SetFloat("VelocityX",Math.Abs(rb.velocity.x));

        animator.SetBool("Disabled",playerControl.disable);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, 1.2f, 0));
    }
}
