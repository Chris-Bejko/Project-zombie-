using UnityEngine;

public class AnyStateAI : State
{

    public Enemy enemy;
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.AnyStateAI;
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        if (enemy.GetHealth() <= 0)
            stateMachine.ChangeState(StateID.Dead);
    }
    public override void Tick()
    {
        base.Tick();
        Rotate();
    }
    private void Rotate()
    {
        var dir = (enemy.Target.transform.position.x - transform.position.x) >= 0 ? 1 : -1;
        transform.localScale = new Vector3(dir, transform.localScale.y, transform.localScale.z);
    }

    private void GameStateChanged(GameState state)
    {
        if (state == GameState.Lore || state == GameState.Paused || state == GameState.UI)
            stateMachine.ChangeState(StateID.Frozen);

        if (state == GameState.Playing)
            stateMachine?.ChangeState(StateID.Idle);

    }

}
