using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : State
{
    public Enemy enemy;
    private float timer;

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Combat;
    }

    public override void Tick()
    {
        base.Tick();
        //enemy.animator.SetTrigger("Combat");
        timer += Time.deltaTime;
        if(timer >= enemy.combatRate)
        {
            timer = 0;
            Comat();
        }

    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Vector2.Distance(enemy.Target.transform.position, transform.position) >= enemy.desiredDistance)
            stateMachine.ChangeState(StateID.Chase);
    }
    private void Comat()
    {
        Debug.Log("Enemy is combating");
    }

    public override void OnEnterState()
    {
        base.OnEnterState();

    }
}
