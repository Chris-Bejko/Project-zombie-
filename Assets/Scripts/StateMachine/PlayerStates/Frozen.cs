using UnityEngine;

public class Frozen : AnyState
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
        player.rb.velocity = Vector2.zero;
    }
}
