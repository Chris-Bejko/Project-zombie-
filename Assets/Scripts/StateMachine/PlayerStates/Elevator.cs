using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : AnyState
{

    Vector3 pos;
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.Elevator;
    }
    public override void Tick()
    {
        var delta = 1f;
        base.Tick();
        var vel = (Vector3)player.rb.velocity;
        player.rb.position = Vector3.MoveTowards(transform.position, pos,  1 / delta);
        
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if(transform.position == pos)
            stateMachine.ChangeState(StateID.Frozen);
    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        //Move to the middle of the elevator, change to frozen
        player.rb.velocity = Vector2.zero;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Elevator"))
            return;

        pos = collision.GetComponent<ElevatorDoor>().inPos.position;

    }
}
