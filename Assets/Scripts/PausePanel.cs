using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnClickedResumeButton()
    {
        GameManager.Instance.Resume();
        UIManager.Instance.ActivePausePanel(false);
    }    
    public void OnClickedSettingButton()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(true);
            UIManager.Instance.ActivePausePanel(false);
        }    
    }   
    public void OnClickedQuitButton()
    {
        if(UIManager.HasInstance)
        {
            GameManager.Instance.EndGame();
        }    
    }    
}
