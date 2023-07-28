using Rewired;

namespace AlphaSource.Characters.MovementStates
{
    public abstract class BaseEnabledState : IMovementState
    {
        protected Player _playerInput;
        protected MovementMediator _movementMediator;

        public BaseEnabledState(MovementMediator movementMediator, Player playerInput)
        {
            _movementMediator = movementMediator;
            _playerInput = playerInput;
        }
        
        public virtual void Enter(MovementStateType previousState)
        {
           
        }

        public virtual void Exit()
        {
            
        }

        public virtual void ExecuteState()
        {
            
        }
    }
}