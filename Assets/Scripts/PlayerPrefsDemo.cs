using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefsDemo : MonoBehaviour
{
    private const string goldkey = "GoldAmount";
    private int goldValue = 0;
    public TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
        LoadGold();
    }

    // Update is called once per frame

    private void LoadGold()
    {
        if (PlayerPrefs.HasKey(goldkey)) 
        {
            goldValue = PlayerPrefs.GetInt(goldkey);
            goldText.text = "Gold: " + goldValue;
            Debug.Log("Current Gold is: " + goldValue);
        }
    }
    private void SaveGold()
    {
        PlayerPrefs.SetInt(goldkey, goldValue);
    }
    public void UpdateGoldAmount()
    {
        goldValue++;
        goldText.text = "Gold: " + goldValue;
    }
    private void OnApplicationQuit()
    {
        SaveGold();
    }
}
