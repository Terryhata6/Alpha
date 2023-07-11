using Rewired;

namespace AlphaSource.Characters.MovementStates.Implementation
{
    public abstract class BaseState : IMovementState
    {
        protected Player _playerInput;
        protected MovementMediator _movementMediator;

        public BaseState(MovementMediator movementMediator, Player playerInput)
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