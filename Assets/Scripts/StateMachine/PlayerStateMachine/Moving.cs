using UnityEngine;

public class Moving : PlayerState
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.Moving;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Player.horizontal == 0 && Player.vertical == 0)
            Player.ChangeState(PlayerStateID.Grounded);

        if (Input.GetKeyDown(KeyCode.Space))
            Player.ChangeState(PlayerStateID.Jumping);

    }

    public override void Tick()
    {
        base.Tick();
        transform.localScale = new Vector3(Mathf.Sign(Player.horizontal), 1, 1);
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();
        Player.rb.velocity = new Vector2(Player.horizontal * Player.moveSpeed, Player.rb.velocity.y);
    }
}