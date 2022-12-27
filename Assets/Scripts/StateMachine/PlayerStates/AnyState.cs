public class AnyState : State
{
    public Player player;

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        this.stateMachine = stateMachine;
        stateID = StateID.AnyState;
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
        if (player.GetHealth() <= 0)
            stateMachine.ChangeState(StateID.Dead);
    }

    private void GameStateChanged(GameState state)
    {
        if (state == GameState.Lore ||state == GameState.Paused || state == GameState.UI)
            stateMachine.ChangeState(StateID.Frozen);

        if (state == GameState.Playing)
            stateMachine.ChangeState(StateID.Grounded);

    }

}
