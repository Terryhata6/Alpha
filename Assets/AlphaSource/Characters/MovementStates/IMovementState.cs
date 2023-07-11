namespace AlphaSource.Characters.MovementStates
{
    public interface IMovementState
    {
        public void Enter(MovementStateType previousState);
        public void Exit();

        public void ExecuteState();
    }
}