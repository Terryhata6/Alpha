using System;

namespace AlphaSource.Services.SaveLoad
{
    [Serializable]
    public class PlayerSave
    {
        public PlayerSave(string name = "player")
        {
            Name = name;
        }
        
        public string Name;
    }
}