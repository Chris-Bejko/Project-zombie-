using UnityEngine;

public class Moving : State
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Machine = stateMachine;
        stateID = StateID.Moving;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Machine.horizontal == 0 && Machine.vertical == 0)
            Machine.ChangeState(StateID.Idle);

    }
}