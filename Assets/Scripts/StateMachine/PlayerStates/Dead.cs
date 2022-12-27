using System.Collections;
using UnityEngine;

public class Dead : State
{
    public Player player;
    private const string animParam = "Death";

    public override void Init(StateMachine machine)
    {
        this.stateMachine = machine;
        stateID = StateID.Dead;
        
    }


    public override void Tick()
    {
        base.Tick();

    }

    public override void CheckConditions()
    {
        base.CheckConditions();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        player.animator.SetTrigger(animParam);
        yield return new WaitForSeconds(2f);
        player.gameObject.SetActive(false);

    }
    public override void OnExitState()
    {
        base.OnExitState();
    }
}
