using UnityEngine;

public class Grounded : Moving
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.Grounded;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();

        if (Input.GetKeyDown(KeyCode.Space))
            Player.ChangeState(PlayerStateID.Jumping);

        if (Input.GetMouseButton(0))
            Player.ChangeState(PlayerStateID.Shooting);

        if (Player.horizontal != 0)
            Player.ChangeState(PlayerStateID.Moving);

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
        //Machine.rb.velocity = Vector2.zero;
    }

}