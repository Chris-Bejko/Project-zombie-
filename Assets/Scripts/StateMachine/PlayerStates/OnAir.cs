using System.Collections;
using UnityEngine;

public class OnAir : AnyState
{
    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine= stateMachine;
        stateID = StateID.OnAir;
        
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Physics2D.OverlapCircle(player.groundCheck.position, player.groundCheckRadius, player.groundLayer))
            stateMachine.ChangeState(StateID.Grounded);

    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();
       
        player.rb.velocity = new Vector2(player.horizontal * player.moveSpeed, player.rb.velocity.y);

    }
    public override void OnEnterState()
    {
        base.OnEnterState();
    }
}
