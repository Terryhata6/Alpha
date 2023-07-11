using Rewired;
using UnityEngine;

namespace AlphaSource.Characters.MovementStates.Implementation
{
    public class IdleState : BaseState
    {
        public IdleState(MovementMediator movementMediator, Player playerInput) : base(movementMediator, playerInput)
        {
        }

        public override void Enter(MovementStateType previousState)
        {
            Debug.Log("Sub");
        }

        public override void Exit()
        {
            
        }

        public override void ExecuteState()
        {
            Debug.Log("Idle");
                
        }
    }
}