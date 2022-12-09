public class Grounded : State
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Machine = stateMachine;
        stateID = StateID.Grounded;
    }
}