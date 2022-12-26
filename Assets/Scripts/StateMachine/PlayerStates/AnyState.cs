using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyState : State
{
    public Player player;

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.AnyState;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (player.GetHealth() <= 0)
            stateMachine.ChangeState(StateID.Dead);
    }
}
