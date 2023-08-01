using System.Collections.Generic;
using AlphaSource.Services.SaveLoad;
using Rewired;

namespace AlphaSource.Services.PlayerDirectory
{
    public class PlayerManager
    {
        private Dictionary<string, GamePlayer> _gamePlayers;
        private ISaveLoadSystem _saveLoadSystem;

        public PlayerManager(ISaveLoadSystem saveLoadSystem)
        {
            _saveLoadSystem = saveLoadSystem;
            _gamePlayers = new Dictionary<string, GamePlayer>();
            
        }


        public void AddFirstPlayer()
        {
            AddPlayer(_saveLoadSystem.GetFirstPlayerInfo());
        }

        public void AddPlayer(PlayerSave playerData)
        {
            AddPlayer(playerData.Name, new GamePlayer(connectedInput: GetInputForPlayer(_gamePlayers.Count)));
        }

        private Player GetInputForPlayer(int index)
        {
            return ReInput.players.GetPlayer(index);
        }

        public void AddPlayer(string nickname, GamePlayer gamePlayer)
        {
            if (!_gamePlayers.ContainsKey(nickname))
            {
                _gamePlayers[nickname] = gamePlayer;
            }
        }

        public void RemovePlayer(string nickname)
        {
            if (_gamePlayers.ContainsKey(nickname))
            {
                _gamePlayers.Remove(nickname);
            }
        }

        public GamePlayer GetPlayer(string nickname)
        {
            if (_gamePlayers.ContainsKey(nickname))
            {
                return _gamePlayers[nickname];
            }

            return null;
        }

        public Dictionary<string, GamePlayer> GetPlayers()
        {
            return _gamePlayers;
        }
    }
}
