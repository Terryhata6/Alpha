using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AlphaSource.Services.SaveLoad
{
    public class SaveLoadSystem
    {
        private PlayerSave _choosedCurrentSave;
        
        public PlayerSave CreateNewSave(string name = "player")
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Create(Application.persistentDataPath 
                                          + $"/{name}SaveData.dat"); 
            PlayerSave data = new PlayerSave();
            data.Name = name;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game data saved!");
            return data;
        }

        /*
         * Debug
         */
        public bool LoadSave(out PlayerSave save, string name = "player")
        {

            save = new PlayerSave("player");
            return false;
            /*
            if (File.Exists(Application.persistentDataPath 
                            + $"/{name}SaveData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = 
                    File.Open(Application.persistentDataPath 
                              + "/MySaveData.dat", FileMode.Open);
                PlayerSave data = (PlayerSave)bf.Deserialize(file);
                file.Close();
                
                if (Validate(data))
                {
                    save = data;
                }
                else
                {
                    save = CreateNewSave(name);
                }

                return true;
            }
            else
            {
                save = CreateNewSave(name);
                return false;
            }
            */
        }
        
        public void ResetData(string name = "player")
        {
            if (File.Exists(Application.persistentDataPath 
                            + $"/{name}SaveData.dat"))
            {
                File.Delete(Application.persistentDataPath 
                            + $"/{name}SaveData.dat");
                Debug.Log("Data reset complete!");
            }
            else
                Debug.LogError("No save data to delete.");
        }

        private bool Validate(PlayerSave data)
        {
            return true;
        }

        public PlayerSave GetFirstPlayerInfo()
        {
            if (_choosedCurrentSave == null)
            {
                LoadSave(out _choosedCurrentSave);
            }
            return _choosedCurrentSave;
        }

        
    }

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