using System;
using UnityEngine;


public class PlayerState : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D _rb;
    private PlayerControl _playerControl;
    public Animator animator;
    public bool onGround;
    public float GroundDistance=1.3f;
    
    

    private void Start()
    {
        _rb=player.GetComponent<Rigidbody2D>();
        _playerControl=player.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        //地面检测
        if (Physics2D.Raycast(transform.position, Vector2.down, GroundDistance, ~(1<<3)))
        {
            onGround = true;
            animator.SetBool(AnimatorParams.OnGround,onGround);
        }
        else
        {
            onGround = false;
            animator.SetBool(AnimatorParams.OnGround,onGround);
        }
        //受伤动画
        animator.SetFloat(AnimatorParams.VelocityY,(_rb.velocity.y));
        animator.SetFloat(AnimatorParams.VelocityX,Math.Abs(_rb.velocity.x));
        animator.SetBool(AnimatorParams.Disable,_playerControl.disable);
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, GroundDistance, 0));
    }
}



