using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayImage;
    public GameObject howToPlayBtn;

    public void OnStartButtonClick()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.StartGame();
        }
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveMenuPanel(false);
            UIManager.Instance.ActiveLoadingPanel(true);
        }
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayBGM(AUDIO.BGM_BGM_01, 0.5f);
        }
    }
    public void OnSettingButtonClick()
    {
        Debug.Log("setting");
        if (UIManager.HasInstance)
        {
            Debug.Log("turnon");
            UIManager.Instance.ActiveSettingPanel(true);
        }
    }
    public void OnHowToPlayButtonClick()
    {
        howToPlayImage.SetActive(true);
        howToPlayBtn.SetActive(false);
    }   
    public void OnHowToPlayButtonImg()
    {
        howToPlayImage.SetActive(false);
        howToPlayBtn.SetActive(true);
    }    
}
