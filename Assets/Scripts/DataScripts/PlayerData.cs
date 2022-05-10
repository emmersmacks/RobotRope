using System.Collections.Generic;
using UnityEngine;
using Ropebot.Data.Controllers.Binary;
using System.IO;
using Ropebot.Data.Bots;

namespace Ropebot.Data
{
    public class PlayerData : MonoBehaviour
    {
        public PlayerDataStruct data;
        private string _path = "/Saves/PlayerData.bs";

        private void Start()
        {
            if (!File.Exists(Application.dataPath + _path))
            {
                SetDefoltValuesData();
            }
            else
            {
                SetDefoltValuesData();

                data = new PlayerDataStruct();
                data = LoadData.Load(ref data, _path);
            }
        }

        private void OnApplicationQuit()
        {
            SaveData.Save(data, _path);
        }

        public void SetDefoltValuesData()
        {
            data = new PlayerDataStruct();
            data.money = 500;
            data.score = 0;
            data.currentBot = new SantiagoBot();
            data.botsInventory = new List<BotData>();
            data.botsInventory.Add(new SantiagoBot());
            SaveData.Save(data, _path);
        }
    }

    [System.Serializable]
    public class PlayerDataStruct
    {
        public int money;
        public int score;
        public BotData currentBot;
        public List<BotData> botsInventory;
    }
}

