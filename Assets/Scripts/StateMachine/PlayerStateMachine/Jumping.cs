using System.Collections;
using UnityEngine;

public class Jumping : State
{
    public Player player;
    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        stateID = StateID.Jumping;
        
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (!Physics2D.OverlapCircle(player.groundCheck.position, player.groundCheckRadius, player.groundLayer))
            stateMachine.ChangeState(StateID.OnAir);
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();

    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        player.animator.SetTrigger("Jump");
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
    }
}
