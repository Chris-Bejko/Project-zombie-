using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class StateMachine : MonoBehaviour
{
    [SerializeField]
    protected StateID currentState;
    [SerializeField]
    protected StateID previousState;

    public List<State> states;
    public static event Action<StateID> OnStateChange;

    public void Awake()
    {
        InitializeStates();
    }

    public void InitializeStates()
    {
        states = GetComponents<State>().ToList();
        foreach (var e in states)
            e.Init(this);

        //currentState = StateID.Moving;
        //ChangeState(StateID.Grounded);
    }

    public void Update()
    {
        GetState(currentState)?.Tick();
        GetState(currentState)?.CheckConditions();
    }

    public void FixedUpdate()
    {
        GetState(currentState)?.PhysicsTick();
    }

    public void ChangeState(StateID newState)
    {

        if (previousState != StateID.None && GetState(previousState) != null)
            GetState(previousState).OnExitState();

        if(currentState != previousState)
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

    public StateID GetCurrentState()
    {
        return currentState;
    }

    public StateID GetPreviousState()
    {
        return previousState;
    }
}
