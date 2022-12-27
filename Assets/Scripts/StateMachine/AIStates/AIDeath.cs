using System.Collections;
using UnityEngine;

public class AIDeath : State
{
    public Enemy enemy;
    private const string animParam = "Death";
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Dead;
    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        enemy.animator.SetTrigger(animParam);
        yield return new WaitForSeconds(0.6f);
        enemy.gameObject.SetActive(false);
    }
}
