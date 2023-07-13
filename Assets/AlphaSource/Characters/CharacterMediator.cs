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
        

        public void Init(string id,  UpdateRunner runner, Player inputPlayer)
        {
            BindMovement(id, runner, inputPlayer);
        }

        private void BindMovement(string id, UpdateRunner runner, Player inputPlayer)
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
            
            _movementMediator.Init(runner, inputPlayer);
        }
    }
}
