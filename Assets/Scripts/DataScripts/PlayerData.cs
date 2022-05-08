using System.Collections.Generic;
using UnityEngine;
using game.data.controller.binary;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public PlayerDataStruct data;
    private string _path = "/Saves/PlayerData.bs";

    private void Start()
    {
        if (!File.Exists(Application.dataPath + _path))
        {
            SetDefoltValuesData();
            Debug.Log("FirstStart");
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
        SaveData.Save(data, _path);
    }
}

[System.Serializable]
public class PlayerDataStruct
{
    public int money;
    public int score;
}
