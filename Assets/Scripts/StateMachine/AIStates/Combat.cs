using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : AnyStateAI
{
    private float timer;
    private const string animParam = "Combat";

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
        if (timer >= enemy.combatRate)
        {
            timer = 0;
            FCombat();
        }

    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (Vector2.Distance(enemy.Target.transform.position, transform.position) >= enemy.desiredDistance)
            stateMachine.ChangeState(StateID.Chase);
    }
    private void FCombat()
    {
        var hit = Physics2D.OverlapCircleAll(enemy.attackPoint.position, enemy.attackRange, enemy.PlayerLayer);
        Debug.LogError(hit.Length);
        foreach (var e in hit)
        {
            if (e.TryGetComponent<IDamageable>(out var damagable))
                damagable.TakeDamage(enemy.damage);
        }
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        enemy.animator.SetTrigger(animParam);
    }
    public override void OnExitState()
    {
        base.OnExitState();
        enemy.animator.ResetTrigger(animParam);
    }

    private void OnDrawGizmosSelected()
    {
        if (enemy.attackPoint == null)
            return;

        Gizmos.DrawSphere(enemy.attackPoint.position, enemy.attackRange);
    }
}
