using Rewired;

namespace AlphaSource.Characters.MovementStates.Implementation
{
    public class DisabledState : BaseState
    {
        public DisabledState(MovementMediator movementMediator, Player playerInput) : base(movementMediator, playerInput)
        {
        }
    }
}