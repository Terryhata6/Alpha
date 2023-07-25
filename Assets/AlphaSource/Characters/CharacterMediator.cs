using AlphaSource.Services.Updater;
using Rewired;
using UnityEngine;
using Zenject;

namespace AlphaSource.Characters
{
    public class CharacterMediator : MonoBehaviour
    {
        public string ID { get; private set; }
        private MovementMediator _movementMediator;
        private SkillsMediator _skillsMediator;
        private ICharacterAnimator _characterAnimator;
        private CharacterCurrentData _currentData;

        public void Init(string id,  UpdateRunner runner, Player inputPlayer)
        {
            _currentData = new CharacterCurrentData();
            BindAnimator();
            BindMovement(id, runner, inputPlayer, _characterAnimator, _currentData);
        }

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
        
        private void BindMovement(string id, UpdateRunner runner, Player inputPlayer,
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
            
            _movementMediator.Init(runner, inputPlayer, characterAnimator, characterCurrentData);
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
