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
        [FormerlySerializedAs("Example")] [SerializeField] private CharacterMediator _example;
        private UpdateRunner _runner;
        private DamageGlobalExecutor _damageGlobalExecutor;
        private SceneCameraManager _sceneCameraManager;
        private string FirstPlayerID = "player0";

        [Inject]
        public void Construct(UpdateRunner runner, DamageGlobalExecutor damageGlobalExecutor, SceneCameraManager sceneCameraManager)
        {
            _sceneCameraManager = sceneCameraManager;
            _runner = runner;
            _damageGlobalExecutor = damageGlobalExecutor;

            CreatePlayerCharacter(FirstPlayerID, transform, ReInput.players.GetPlayer(0));
        }

        public CharacterMediator CreatePlayerCharacter(string id, Transform playerSpawner, Player inputPlayer)
        {
            var character = Instantiate(_example, playerSpawner.position, Quaternion.identity);
            _sceneCameraManager.SetupCharacterCamera(character);
            character.Init(id, _runner, inputPlayer);
            return character;
        }
    }
}