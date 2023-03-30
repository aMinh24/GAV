using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public TextMeshProUGUI playerLivesText;
    private void Start()
    {
        if (SingletonDemo.Instance != null)
        {
            playerLivesText.text = "Player Lives: " + SingletonDemo.Instance.Playerlives;
        }    
        
    }
    public void AttackPlayer()
    {

        if (SingletonDemo.Instance != null)
        {
            SingletonDemo.Instance.UpdatePlayerLives(1);
        }
        playerLivesText.text = "Player Lives: "+SingletonDemo.Instance.Playerlives;
    }    
    public void ChangeScene()
    {
        SceneManager.LoadScene("SingletonDemo2");
    }    
}
