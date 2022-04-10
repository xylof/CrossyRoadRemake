using System;
using UnityEngine;

namespace SDA.Core
{
    [Serializable]
    public class PlayerData
    {
        public int bestScore;

        public PlayerData()
        {
            bestScore = 30;
        }
    }

    public class SaveSystem
    {
        private PlayerData loadedData;
        public PlayerData LoadedData => loadedData;

        public void LoadData()
        {
            if (PlayerPrefs.HasKey("CROSSY SAVE3"))
            {
                string json = PlayerPrefs.GetString("CROSSY SAVE3");
                loadedData = JsonUtility.FromJson<PlayerData>(json);
            }
            else
            {
                loadedData = new PlayerData();
                SaveData();
            }
        }

        public void SaveData()
        {
            string json = JsonUtility.ToJson(loadedData);
            PlayerPrefs.SetString("CROSSY SAVE3", json);
        }
    }
}
