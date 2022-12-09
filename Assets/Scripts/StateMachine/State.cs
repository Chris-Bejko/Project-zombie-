using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public PlayerStateID stateID;
    public PlayerStateMachine Player;

    public virtual void Init(PlayerStateMachine stateMachine)
    {
        Player = stateMachine;
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
        Debug.LogError("Entered state : " + stateID);
    }

    public virtual void OnExitState()
    {
        Debug.LogError("Exited state: " + stateID);
    }
}


public enum PlayerStateID
{
    None,
    Idle,
    Moving,
    Jumping,
    Shooting,
    Grounded,
    OnAir,
}