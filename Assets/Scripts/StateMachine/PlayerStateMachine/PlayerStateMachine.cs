using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public float horizontal, vertical;
    public new void Awake()
    {
        InitializeStates();
    }

    public override void InitializeStates()
    {
        base.InitializeStates();
        states = GetComponents<State>().ToList();
        foreach (var e in states)
            e.Init(this);
    }


    public override void Update()
    {
        base.Update();

        horizontal = Input.GetAxisRaw("Horizontal");
    }
}
