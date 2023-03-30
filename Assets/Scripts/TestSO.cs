using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSO : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI strength;
    public TextMeshProUGUI ability;
    public TextMeshProUGUI inteligence;
    // Start is called before the first frame update
    void Start()
    {
        DataManage.Instance.Init();
        LoadData();
    }

    private void LoadData()
    {
        var dataSO = DataManage.Instance.PlayerData;
        damage.SetText($"Damage {dataSO.playerData.Damage}");
        health.SetText($"Health {dataSO.playerData.Health}");
        strength.SetText($"Strength {dataSO.playerData.Strength}");
        ability.SetText($"Ability {dataSO.playerData.Ability}");
        inteligence.SetText($"Inteligence {dataSO.playerData.Inteligence}");
        DataManage.Instance.SavePlayerData();
        
    }    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void UpdatePlayerData(int amount)
    {
        var dataSO = DataManage.Instance.PlayerData;
        dataSO.playerData.Health += amount;
        dataSO.playerData.Damage += amount;
        dataSO.playerData.Strength += amount;
        dataSO.playerData.Ability += amount;
        dataSO.playerData.Inteligence += amount;
        DataManage.Instance.SavePlayerData();
        LoadData();
    }
}
