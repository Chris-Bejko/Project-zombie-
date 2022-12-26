using System.Collections;
using System.Collections.Generic;
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
        Debug.LogError("Enemy death state entered");
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        enemy.animator.SetTrigger(animParam);
        yield return new WaitForSeconds(0.45f);
        enemy.gameObject.SetActive(false);
    }
}
