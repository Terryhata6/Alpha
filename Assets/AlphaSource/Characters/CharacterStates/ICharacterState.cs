namespace AlphaSource.Characters.CharacterStates
{
    public interface ICharacterState
    {
        public void Enter(CharacterStateType previousState);
        public void Exit();

        public void ExecuteState();
    }
    
}