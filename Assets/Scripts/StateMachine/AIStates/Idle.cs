using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{

    public Enemy enemy;
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Idle;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (enemy.Target.GetPlatform() == enemy.Platform)
            stateMachine.ChangeState(StateID.Chase);

    }

}
