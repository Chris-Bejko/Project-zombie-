using System.Collections;
using UnityEngine;

public class OnAir : PlayerState
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.OnAir;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Physics2D.OverlapCircle(Player.groundCheck.position, Player.groundCheckRadius, Player.groundLayer))
            Player.ChangeState(PlayerStateID.Grounded);

    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();
       
        Player.rb.velocity = new Vector2(Player.horizontal * Player.moveSpeed, Player.rb.velocity.y);

    }
    public override void OnEnterState()
    {
        base.OnEnterState();
    }
}
