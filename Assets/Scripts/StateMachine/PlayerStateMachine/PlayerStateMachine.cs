using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public float horizontal, vertical;

    public Animator animator;
    
    public Rigidbody2D rb;

    public float groundCheckRadius, moveSpeed, jumpForce;

    public Transform groundCheck;
    
    public LayerMask groundLayer;

    public float lastDirection;

    public Transform firePoint;

    public float fireRate;

    public new void Awake()
    {
        InitializeStates();
    }

    public override void InitializeStates()
    {
        base.InitializeStates();
        states = GetComponents<PlayerState>().ToList();
        foreach (var e in states)
            e.Init(this);

        currentState = PlayerStateID.Moving;
        ChangeState(PlayerStateID.Grounded);
    }


    public override void Update()
    {
        base.Update();

        horizontal = Input.GetAxisRaw("Horizontal");
        Animate();
    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        if (horizontal != 0)
            transform.localScale = new Vector3(Mathf.Sign(horizontal), transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
