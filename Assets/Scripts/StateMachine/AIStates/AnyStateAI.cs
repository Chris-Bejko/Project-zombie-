using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyStateAI : State
{

    public Enemy enemy;
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.AnyStateAI;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (enemy.GetHealth() <= 0)
            stateMachine.ChangeState(StateID.Dead);
    }
    public override void Tick()
    {
        base.Tick();
        Rotate();
    }
    private void Rotate()
    {
        var dir = (enemy.Target.transform.position.x - transform.position.x) >= 0 ? 1 : -1;
        transform.localScale = new Vector3(dir, transform.localScale.y, transform.localScale.z);
    }

}
