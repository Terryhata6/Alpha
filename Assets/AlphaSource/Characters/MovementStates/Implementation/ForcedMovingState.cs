using Rewired;

namespace AlphaSource.Characters.MovementStates.Implementation
{
    public class ForcedMovingState : BaseEnabledState
    {
        private MovementStateType _previousState;
        private float _previousCurrentSpeed;

        public ForcedMovingState(MovementMediator movementMediator, Player playerInput) : base(movementMediator, playerInput)
        {
        }

        public override void Enter(MovementStateType previousState)
        {
            base.Enter(previousState);
            _previousState = previousState;
        }

        public override void ExecuteState()
        {
            base.ExecuteState();
            _movementMediator.ExecuteCurrentForcedMovement(ReturnToPreviousState);
        }

        private void ReturnToPreviousState()
        {
            _movementMediator.ChangeState(_previousState);
            _movementMediator.SetSpeed(_previousCurrentSpeed);
        }
    }
}