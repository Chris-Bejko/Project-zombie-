using UnityEngine;

public class Shooting : Grounded
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.Shooting;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();

        if (Input.GetMouseButtonUp(0))
            Player.ChangeState(Player.GetPreviousState());
    }
}