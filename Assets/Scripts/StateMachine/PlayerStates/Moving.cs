using UnityEngine;

public class Moving : State
{
    public Player player;
    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        stateID = StateID.Moving;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (player.horizontal == 0)
            stateMachine.ChangeState(StateID.Grounded);

        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(StateID.Jumping);

    }

    public override void Tick()
    {
        base.Tick();
        player.lastDirection = player.horizontal;
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();
        player.rb.velocity = new Vector2(player.horizontal * player.moveSpeed, player.rb.velocity.y);
    }


}