using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chase : State
{
    public Enemy enemy;

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Chase;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        enemy.hasSeenPlayerOnce = true;
    }
    public override void Tick()
    {

        base.Tick(); 
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemy.Target.transform.position.x, transform.position.y), enemy.moveSpeed * Time.deltaTime);
    }
    public override void PhysicsTick()
    {
        base.PhysicsTick();
        /*Debug.LogError("Chasing");
        var desiredVelocity = (enemy.Target.transform.position - transform.position) * enemy.moveSpeed;
        Debug.LogError(desiredVelocity);
        var deltaVelocity = (Vector2)desiredVelocity - enemy.rb.velocity;
        Debug.LogError(deltaVelocity);
        //enemy.rb.AddForce(deltaVelocity * Time.fixedDeltaTime);
        enemy.rb.velocity = deltaVelocity * Time.fixedDeltaTime;
        Debug.LogError(enemy.rb.velocity);*/
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Vector2.Distance(enemy.Target.transform.position, transform.position) < enemy.desiredDistance)
            stateMachine.ChangeState(StateID.Combat);

        //if (enemy.GetHealth() <= 0)
          //  stateMachine.ChangeState(StateID.Dead);
    }
}
