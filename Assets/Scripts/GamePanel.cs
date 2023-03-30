using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI numberofCherries; 
    public TextMeshProUGUI NumberOfCherries => numberofCherries;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private float timeRemaining;
    private bool timerIsRunning = false;
    private void Awake()
    {
        SetTimeRemain(120);
    }
    private void OnEnable()
    {
        timerIsRunning = true;
        SetTimeRemain(120);
        ItemCollector.collectCherryDelegate += OnPlayerCollect;
    }
    private void OnDisable()
    {
        ItemCollector.collectCherryDelegate -= OnPlayerCollect;
    }
    private void OnPlayerCollect(int value)
    {
        numberofCherries.SetText(value.ToString());
    }   
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minute, second);
    }
    public void SetTimeRemain(float v)
    {
        timeRemaining = v;
    }
    private void Update()
    {
        if (timerIsRunning)
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining= 0;
                timerIsRunning= false;
                if (UIManager.HasInstance && GameManager.HasInstance && AudioManager.HasInstance)
                {
                    //AudioManager.Instance.PlaySE(AUDIO.SE_LOSE);
                    UIManager.Instance.ActiveLosePanel(true);
                    GameManager.Instance.PauseGame();
                }
            }
    }
}
