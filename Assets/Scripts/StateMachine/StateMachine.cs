using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public StateID currentState;

    public StateID previousState;

    public List<State> states;
    public static event Action<StateID> OnStateChange;

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
        GetState(currentState).Tick();
        GetState(currentState).CheckConditions();
    }

    public void FixedUpdate()
    {
        GetState(currentState).PhysicsTick();
    }

    public void ChangeState(StateID newState)
    {

        if (previousState != StateID.None && GetState(previousState) != null)
            GetState(previousState).OnExitState();

        previousState = currentState;

        if (newState != StateID.None && GetState(newState) != null)
            GetState(newState).OnEnterState();

        currentState = newState;

        OnStateChange?.Invoke(currentState);
    }


    private State GetState(StateID stateID)
    {
        foreach (var state in states)
        {
            if (state.stateID == stateID)
                return state;
        }

        return null;
    }
}
