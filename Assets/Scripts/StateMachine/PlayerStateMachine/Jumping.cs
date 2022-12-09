using System.Collections;
using UnityEngine;

public class Jumping : PlayerState
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.Jumping;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (!Physics2D.OverlapCircle(Player.groundCheck.position, Player.groundCheckRadius, Player.groundLayer))
            Player.ChangeState(PlayerStateID.OnAir);
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();

    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        Player.animator.SetTrigger("Jump");
        Player.rb.velocity = new Vector2(Player.rb.velocity.x, Player.jumpForce);
    }
}
