using System;
using System.Collections.Generic;
using AlphaSource.Characters.MovementRules;
using AlphaSource.Characters.MovementStates;
using AlphaSource.Characters.MovementStates.Implementation;
using AlphaSource.Services.Updater;
using AlphaSource.Services.Updater.Interfaces;
using Rewired;
using UnityEngine;

namespace AlphaSource.Characters
{
    public class MovementMediator : MonoBehaviour, IUpdatable
    {
        #region Dependencies

        private UpdateRunner _runner;
        private Player _playerInput;

        #endregion
        #region StateHandling

        private Dictionary<MovementStateType, IMovementState> _states;
        private MovementStateType _currentState;
        private BaseForcedMovementRule _currentBaseForcedRule;

        #endregion
        #region Values

        private Vector3 _currentMovementDirection = Vector3.zero;
        private float _baseSpeedLimit = 10f;
        private float _currentSpeed = 1f;


        public Vector3 Direction => _currentMovementDirection;
        #endregion

        public void Init(UpdateRunner runner, Player inputPlayer)
        {
            _runner = runner;
            _runner.Subscribe(this);
            BindInput(inputPlayer);
            
            InitMovementStates();
        }
        private void BindInput(Player inputPlayer)
        {
            _playerInput = inputPlayer;
        }
        private void InitMovementStates()
        {
            _states = new Dictionary<MovementStateType, IMovementState>();
            _states.Add(MovementStateType.Disabled, new DisabledState());
            _states.Add(MovementStateType.Idle, new IdleState(this, _playerInput));
            _states.Add(MovementStateType.SimpleMoving, new MovingState(this, _playerInput));
            _states.Add(MovementStateType.ForcedMoving, new ForcedMovingState(this, _playerInput));

            _currentState = MovementStateType.Disabled;
            ChangeState(MovementStateType.Idle);
        }
        public void ChangeState(MovementStateType state)
        {
            _states[_currentState].Exit();
            var previousState = _currentState;
            _currentState = state;
            _states[_currentState].Enter(previousState);
        }
        public void Execute()
        {
            _states[_currentState].ExecuteState();
        }
        public void CalculateDirection()
        {
            _currentMovementDirection.x = _playerInput.GetAxis(RewiredConsts.Action.HorizontalAxis);
            _currentMovementDirection.z = _playerInput.GetAxis(RewiredConsts.Action.VerticalAxis);
            _currentMovementDirection.y = 0;
        }
        public void OnDestroy()
        {
            if (_runner != null)
            {
                _runner.Unsubscribe(this);
            }
        }
        public void Move()
        {
            transform.Translate(Direction * _currentSpeed);
        }
        public void ExecuteCurrentForcedMovement(Action onForcedMovementEndCallback)
        {
            _currentBaseForcedRule.ExecuteMovementRule(this, onForcedMovementEndCallback);
        }

        private float RecalculateSpeed()
        {
            return _baseSpeedLimit;
        }

        public void SetSpeed(float previousCurrentSpeed)
        {
            _currentSpeed = previousCurrentSpeed;
        }
    }
    
}