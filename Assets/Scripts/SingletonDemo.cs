using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDemo : MonoBehaviour
{
    public static SingletonDemo Instance;
    private int playerlives = 3;
    public int Playerlives => playerlives;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void UpdatePlayerLives(int amount)
    {
        playerlives -= amount;
    }    
}
