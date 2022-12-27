using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFrozen : AnyStateAI
{
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Frozen;
    }
    public override void PhysicsTick()
    {
        base.PhysicsTick();
        enemy.rb.velocity = Vector2.zero;
    }
}
