using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManage : MonoBehaviour
{
    public static DataManage Instance;
    public DataSO PlayerData;
    private string dataFilePath;
    private void Awake()
    {
        if (Instance != null && Instance!= this)
        { 
            Destroy(this); 
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }    
    public void Init()
    {
        dataFilePath = Application.persistentDataPath + "/playerdata.jason";
        Debug.Log(dataFilePath);
        this.LoadPlayerData();
    }    
    private void WritePlayerDataSO()
    {
        string toJson = JsonUtility.ToJson(PlayerData);
        File.WriteAllText(dataFilePath, toJson);
    }    
    private string ReadPlayerDataSO()
    {
        if (File.Exists(dataFilePath))
        {
            return File.ReadAllText(dataFilePath);
        }
        return null;
    }    
    public void LoadPlayerData()
    {
        string fromJson = ReadPlayerDataSO();
        if (fromJson == null)
        {
            WritePlayerDataSO();
            fromJson = ReadPlayerDataSO();
        }
        JsonUtility.FromJsonOverwrite(fromJson, PlayerData);
    }    
    public void SavePlayerData()
    {
        WritePlayerDataSO();
    }    
}
