using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dead : PlayerState
{
    public override void Init(PlayerStateMachine machine)
    {
        this.Player = machine;
        stateID = PlayerStateID.Dead;
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
        Player.animator.SetTrigger("Die");
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }
}
