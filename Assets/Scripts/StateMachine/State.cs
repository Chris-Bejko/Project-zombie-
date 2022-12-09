using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class State : MonoBehaviour
{
    public StateID stateID;
    public PlayerStateMachine Machine;

    public virtual void Init(PlayerStateMachine stateMachine)
    {
        Machine = stateMachine;
    }

    public virtual void Tick()
    {

    }

    public virtual void PhysicsTick()
    {

    }
    public virtual void CheckConditions()
    {

    }

    public virtual void OnEnterState()
    {

    }

    public virtual void OnExitState()
    {

    }
}


public enum StateID
{
    None,
    Idle,
    Moving,
    Jumping,
    Shooting,
    Grounded
}