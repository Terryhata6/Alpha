using System.Collections.Generic;
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
        private UpdateRunner _runner;
        private Player _playerInput;
        private Dictionary<MovementStateType, IMovementState> _states;
        private MovementStateType _currentState;

        public void Init(UpdateRunner runner, Player inputPlayer)
        {
            _runner = runner;
            _runner.Subscribe(this);
            BindInput(inputPlayer);
            InitMovementStates();
        }

        private void InitMovementStates()
        {
            _states = new Dictionary<MovementStateType, IMovementState>();
            _states.Add(MovementStateType.Disabled, new DisabledState(this,_playerInput));
            _states.Add(MovementStateType.Idle, new IdleState(this, _playerInput));
            _states.Add(MovementStateType.SimpleMoving, new MovingState(this, _playerInput));

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
        
        private void BindInput(Player inputPlayer)
        {
            _playerInput = inputPlayer;
        }

        public void Execute()
        {
            _states[_currentState].ExecuteState();
        }

        public void OnDestroy()
        {
            if (_runner != null)
            {
                _runner.Unsubscribe(this);
            }
        }
    }
}