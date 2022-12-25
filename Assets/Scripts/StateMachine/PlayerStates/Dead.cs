using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dead : State
{
    public Player player;

    public override void Init(StateMachine machine)
    {
        this.stateMachine = machine;
        stateID = StateID.Dead;
        
    }


    public override void Tick()
    {
        base.Tick();

    }

    public override void CheckConditions()
    {
        base.CheckConditions();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        player.animator.SetTrigger("Die");
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }
}
