using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Idle : State
{
    public override void Init(PlayerStateMachine machine)
    {
        this.Machine = machine;
        stateID = StateID.Idle;
    }


    public override void Tick()
    {
        base.Tick();

    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if(Machine.horizontal != 0 || Machine.vertical != 0)
        {
            Machine.ChangeState(StateID.Moving);
        }
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
