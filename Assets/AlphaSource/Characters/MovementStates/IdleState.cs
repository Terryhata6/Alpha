using Rewired;

namespace AlphaSource.Characters.MovementStates
{
    public class IdleState : BaseEnabledState
    {
        public IdleState(MovementMediator movementMediator, Player playerInput) : base(movementMediator, playerInput)
        {
        }

        public override void Enter(MovementStateType previousState)
        {
            base.Enter(previousState);
            _playerInput.AddInputEventDelegate(CheckInput, UpdateLoopType.Update, InputActionEventType.AxisActive, RewiredConsts.Action.HorizontalAxis);
            _playerInput.AddInputEventDelegate(CheckInput, UpdateLoopType.Update, InputActionEventType.AxisActive, RewiredConsts.Action.VerticalAxis);
        }

        private void CheckInput(InputActionEventData obj)
        {
            _movementMediator.ChangeState(MovementStateType.SimpleMoving);
        }

        public override void Exit()
        {
            base.Exit();
            _playerInput.RemoveInputEventDelegate(CheckInput, UpdateLoopType.Update, InputActionEventType.AxisActive, RewiredConsts.Action.HorizontalAxis);
            _playerInput.RemoveInputEventDelegate(CheckInput, UpdateLoopType.Update, InputActionEventType.AxisActive, RewiredConsts.Action.VerticalAxis);
        }

        public override void ExecuteState()
        {
            
            
        }
    }
}