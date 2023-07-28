using AlphaSource.Characters;
using Rewired;

namespace AlphaSource.PlayerDirectory
{
    /*
     * Класс представляет собой хранилище Каждого отдельного игрока-человека, ссылки на его данные 
     */
    public class GamePlayer
    {
        private Player _connectedInput;
        private CharacterMediator _createdPlayerCharacter;
        public Player GetInput => _connectedInput;

        public GamePlayer(Player connectedInput)
        {
            _connectedInput = connectedInput;
        }

        public void SetupCharacter(CharacterMediator createdPlayerCharacter)
        {
            _createdPlayerCharacter = createdPlayerCharacter;
        }
    }
}