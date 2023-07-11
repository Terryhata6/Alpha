using System;
using Rewired;
using UnityEngine;

namespace AlphaSource.Characters.MovementStates.Implementation
{
    public class MovingState : BaseState
    {
        public MovingState(MovementMediator movementMediator, Player playerInput) : base(movementMediator, playerInput)
        {
        }

        public override void Enter(MovementStateType previousState)
        {
            
            
        }

        public override void Exit()
        {
           
        }

        public override void ExecuteState()
        {
            Debug.Log("Moving");
        }
    }
}