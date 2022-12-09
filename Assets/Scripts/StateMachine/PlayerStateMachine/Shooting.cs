internal class Shooting : State
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Machine = stateMachine;
        stateID = StateID.Shooting;
    }
}