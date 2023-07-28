using System;
using System.Collections;
using AlphaSource.Characters;
using UnityEngine;
using Zenject;

namespace AlphaSource.PlayerDirectory
{
    
    /*
     * Этот класс отвечает за точку входа на сцену, инициализацию игроков и их размещение. Он должен осуществлять свою деятельность сразу после проброса всех зависимостей
     */
    public class SceneRunner : MonoBehaviour
    {
        private CharacterFabric _characterFabric;
        private PlayerManager _playerManager;

        
        public void Init(PlayerManager playerManager,CharacterFabric characterFabric)
        {
            _playerManager = playerManager;
            _characterFabric = characterFabric;
        }

        
        //Юзаем start пока нет Сцен менеджера TODO CallBySceneManager
        private void Start()
        {
            _playerManager.AddFirstPlayer();
            
            
            
            InitializePlayers(_playerManager, _characterFabric);
        }

        
        private void InitializePlayers(PlayerManager playerManager, CharacterFabric characterFabric)
        {
            foreach (var player in playerManager.GetPlayers())
            {
                player.Value.SetupCharacter(characterFabric.CreatePlayerCharacter(Vector3.zero, player.Value.GetInput));
            }
        }
    }
}