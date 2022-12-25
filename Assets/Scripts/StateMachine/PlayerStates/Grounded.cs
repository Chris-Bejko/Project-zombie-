using UnityEngine;

public class Grounded : Moving
{
    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        stateID = StateID.Grounded;

    }

    public override void CheckConditions()
    {
        base.CheckConditions();

        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(StateID.Jumping);

        if (Input.GetMouseButton(0))
            stateMachine.ChangeState(StateID.Shooting);

        if (player.horizontal != 0)
            stateMachine.ChangeState(StateID.Moving);

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
        //Machine.rb.velocity = Vector2.zero;
    }

}