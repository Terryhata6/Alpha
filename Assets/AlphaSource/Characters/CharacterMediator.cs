using System.Collections.Generic;
using AlphaSource.Characters.CharacterStates;
using AlphaSource.Services.Updater;
using AlphaSource.Services.Updater.Interfaces;
using Rewired;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace AlphaSource.Characters
{
    public class CharacterMediator : MonoBehaviour, IUpdatable
    {
        [SerializeField] private string _id;
        public string ID { get => _id; private set  => _id = value; }

        [Header("Dependencies")]
        private UpdateRunner _runner;
        private Player _inputPlayer;

        [Header("Components")]
        private MovementMediator _movementMediator;
        private SkillsMediator _skillsMediator;
        private ICharacterAnimator _characterAnimator;
        private CharacterCurrentData _currentData;
        [SerializeField] public CharacterStateType CurrentStateType;

        private Dictionary<CharacterStateType, ICharacterState> _characterStates;
        [Header("Config")] public CharacterStateType StartState = CharacterStateType.Living;
        
        public void Init(UpdateRunner runner, Player inputPlayer)
        {
            _inputPlayer = inputPlayer;
            _runner = runner;
            _runner.Subscribe(this);
            
            _currentData = new CharacterCurrentData();
            BindAnimator();
            BindMovement(_inputPlayer, _characterAnimator, _currentData);
            InitCharacterStates();
        }

        public virtual void InitCharacterStates()
        {
            _characterStates = new Dictionary<CharacterStateType, ICharacterState>();
            _characterStates.Add(CharacterStateType.Grace, new GraceCharacterState());
            _characterStates.Add(CharacterStateType.Living, new LivingCharacterState(_movementMediator));
            _characterStates.Add(CharacterStateType.Dead, new DeadCharacterState());

            ChangeState(StartState);
        }

        public void ChangeState(CharacterStateType nextState)
        {
            
            var previousState = CurrentStateType;
            if(_characterStates.ContainsKey(previousState))
                _characterStates[CurrentStateType].Exit();
            CurrentStateType = nextState;
            _characterStates[nextState].Enter(previousState);
        }

        public void Execute() => _characterStates[CurrentStateType].ExecuteState();

        private void BindAnimator()
        {
            if (_characterAnimator == null)
            {
                if (TryGetComponent(out _characterAnimator))
                {
                    
                }
                else
                {
                    _characterAnimator = gameObject.AddComponent<CharacterAnimator>();
                }
            }

            _characterAnimator.Init();
        }
        private void BindMovement(Player inputPlayer,
            ICharacterAnimator characterAnimator, CharacterCurrentData characterCurrentData)
        {
            if (_movementMediator == null)
            {
                if (TryGetComponent(out _movementMediator))
                {
                    
                }
                else
                {
                    _movementMediator = gameObject.AddComponent<MovementMediator>();
                }
            }
            
            _movementMediator.Init(inputPlayer, characterAnimator, characterCurrentData);
        }
        
        
        public void OnDisable()
        {
            if (_runner != null)
            {
                _runner.Unsubscribe(this);
            }
        }
    }

    public class CharacterCurrentData
    {
        public Vector3 WorldMousePointerData;
        
        public CharacterCurrentData()
        {
            
        }
        
        
    }
}
