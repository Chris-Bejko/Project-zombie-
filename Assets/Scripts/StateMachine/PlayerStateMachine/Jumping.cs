internal class Jumping : State
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Machine = stateMachine;
        stateID = StateID.Jumping;
    }
}