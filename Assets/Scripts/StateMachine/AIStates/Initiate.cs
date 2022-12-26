using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Initiate : AnyStateAI
{
    private const string animParam = "Initiate";
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Initiate;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        //Do initiation
        enemy.animator.SetTrigger(animParam);
        StartCoroutine(InitiateJump());
    }
    public override void OnExitState()
    {
        base.OnExitState();
        enemy.animator.ResetTrigger(animParam);
    }
    private IEnumerator InitiateJump()
    {
        var dir = enemy.Target.transform.position - transform.position;
        enemy.rb.AddForce(dir * enemy.initiateForce, ForceMode2D.Impulse);
        enemy.rb.AddForce(Vector2.up * enemy.initiateForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        stateMachine.ChangeState(StateID.Chase);
    }
}
