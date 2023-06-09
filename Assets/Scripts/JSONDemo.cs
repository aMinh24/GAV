﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class JSONDemo : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI playerGold;
    public ListPlayer listPlayer;
    private string json;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData playerData = new PlayerData()
        {
            Name = "Cat",
            Level = "1",
            Gold = 100
        };
       //json = JsonUtility.ToJson(playerData);
        json = JsonUtility.ToJson(listPlayer);  // chuyển thành dạng dữ liệu json
        Debug.Log(json);
    }
    public void LoadPlayerData()
    {
        string loadJSON = File.ReadAllText(Application.dataPath + "/Data/saveFile.json");
        if (loadJSON !=null)
        {
            ListPlayer loadedPlayerData = JsonUtility.FromJson<ListPlayer>(loadJSON);
            playerName.text = "Player Name: " + loadedPlayerData.PlayerDatas[1].Name;
            playerLevel.text = "Player Name: " + loadedPlayerData.PlayerDatas[1].Level;
            playerGold.text = "Player Name: " + loadedPlayerData.PlayerDatas[1].Gold;
        }    
    }   
    public void SaveJsonFile()
    {
        File.WriteAllText(Application.dataPath + "/Data/saveFile.json", json);
    }      
    public void UpdateData()
    {
        PlayerData updateData = new PlayerData
        {
            Name = "Dog",
            Level = "2",
            Gold = 1000
        };
        playerName.text = "Player Name: " + updateData.Name;
        playerLevel.text = "Player Name: " + updateData.Level;
        playerGold.text = "Player Name: " + updateData.Gold;
    }    
}
