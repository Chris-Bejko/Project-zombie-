using System.Collections;
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
        GameManager.Instance.AudioManager.PlayAudio(AudioManager.AudioType.Initiate);
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
        enemy.rb.AddForce(10 * enemy.initiateForce * Vector2.up, ForceMode2D.Force);
        yield return new WaitForSeconds(0.5f);
        stateMachine.ChangeState(StateID.Chase);
    }
}
