namespace AlphaSource.Characters.CharacterStates
{
    public class LivingCharacterState : ICharacterState
    {
        private MovementMediator _movementMediator;

        public LivingCharacterState(MovementMediator movementMediator)
        {
            _movementMediator = movementMediator;
        }

        public void Enter(CharacterStateType previousState)
        {
            
        }

        public void Exit()
        {
            
        }

        public void ExecuteState()
        {
            _movementMediator.Execute();
        }
    }
}