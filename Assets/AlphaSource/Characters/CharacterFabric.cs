using AlphaSource.Services.Camera;
using AlphaSource.Services.Damage;
using AlphaSource.Services.Updater;
using Rewired;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace AlphaSource.Characters
{
    public class CharacterFabric : MonoBehaviour
    {
        [SerializeField] private CharacterMediator _example;
        private UpdateRunner _runner;
        private DamageGlobalExecutor _damageGlobalExecutor;
        private SceneCameraManager _sceneCameraManager;

        
        public void Init(UpdateRunner runner, DamageGlobalExecutor damageGlobalExecutor, SceneCameraManager sceneCameraManager)
        {
            _sceneCameraManager = sceneCameraManager;
            _runner = runner;
            _damageGlobalExecutor = damageGlobalExecutor;
        }

        public CharacterMediator CreatePlayerCharacter(Vector3 playerSpawnPosition, Player inputPlayer)
        {
            var character = Instantiate(_example, playerSpawnPosition, Quaternion.identity);
            if(_sceneCameraManager)
            _sceneCameraManager.SetupClientCamera(character);
            character.Init(_runner, inputPlayer);
            return character;
        }
    }
}