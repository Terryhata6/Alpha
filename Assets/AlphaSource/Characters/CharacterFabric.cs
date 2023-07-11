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
        private string FirstPlayerID = "player0";

        [Inject]
        public void Construct(UpdateRunner runner)
        {
            _runner = runner;
            
            CreatePlayerCharacter(FirstPlayerID, transform, ReInput.players.GetPlayer(0));
        }

        public CharacterMediator CreatePlayerCharacter(string id, Transform playerSpawner, Player inputPlayer)
        {
            var character = Instantiate(_example, playerSpawner.position, Quaternion.identity);
            character.Init(id, _runner, inputPlayer);
            return character;
        }
    }
}