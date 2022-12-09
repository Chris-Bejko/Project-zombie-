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
        ChangeState(PlayerStateID.Idle);
    }


    public override void Update()
    {
        base.Update();

        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
