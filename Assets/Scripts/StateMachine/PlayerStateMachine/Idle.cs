using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Idle : Grounded
{
    public override void Init(PlayerStateMachine machine)
    {
        this.Player = machine;
        stateID = PlayerStateID.Idle;
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
        Debug.LogError("Entered Idle State");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.LogError("Exited Idle State");
    }
}
