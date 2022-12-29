using UnityEngine;

public class Idle : State
{
    public Enemy enemy;

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Idle;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Mathf.Abs(enemy.Target.transform.position.x - transform.position.x) <= enemy.minDistance)
            stateMachine.ChangeState(StateID.Initiate);

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        gameObject.SetActive(true);

    }
}
