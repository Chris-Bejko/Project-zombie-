using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField]
    protected PlayerStateID currentState;
    [SerializeField]
    protected PlayerStateID previousState;

    protected List<PlayerState> states;
    public static event Action<PlayerStateID> OnStateChange;

    public virtual void Awake()
    {
        InitializeStates();
    }

    public virtual void InitializeStates()
    {
        //state.Add(new State(StateID.Example);
    }

    public virtual void Update()
    {
        GetState(currentState)?.Tick();
        GetState(currentState)?.CheckConditions();
    }

    public void FixedUpdate()
    {
        GetState(currentState)?.PhysicsTick();
    }

    public void ChangeState(PlayerStateID newState)
    {

        if (previousState != PlayerStateID.None && GetState(previousState) != null)
            GetState(previousState).OnExitState();

        if(currentState != previousState)
            previousState = currentState;

        if (newState != PlayerStateID.None && GetState(newState) != null)
            GetState(newState).OnEnterState();

        currentState = newState;

        OnStateChange?.Invoke(currentState);
    }


    private PlayerState GetState(PlayerStateID stateID)
    {
        foreach (var state in states)
        {
            if (state.stateID == stateID)
                return state;
        }

        return null;
    }

    public PlayerStateID GetCurrentState()
    {
        return currentState;
    }

    public PlayerStateID GetPreviousState()
    {
        return previousState;
    }
}
