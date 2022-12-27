using UnityEngine;

public class Chase : AnyStateAI
{
    private const string animParam = "Chase";

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Chase;
    }

    public override void Tick()
    {
        base.Tick(); 
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemy.Target.transform.position.x, transform.position.y), enemy.moveSpeed * Time.deltaTime);
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Vector2.Distance(enemy.Target.transform.position, transform.position) < enemy.desiredDistance)
            stateMachine.ChangeState(StateID.Combat);

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        enemy.hasSeenPlayerOnce = true;
        enemy.animator.SetTrigger(animParam);
    }

    public override void OnExitState()
    {
        base.OnExitState();
        enemy.animator.ResetTrigger(animParam);
    }


}
