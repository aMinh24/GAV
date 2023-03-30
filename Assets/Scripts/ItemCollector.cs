using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public delegate void CollectCherry(int Cherry);          //định nghĩa hàm delegate
    public static CollectCherry collectCherryDelegate;      //khai báo hàm delegate
    private int cherries = 0;
    private void Start()
    {
        if (GameManager.HasInstance)
        {
            cherries = GameManager.Instance.Cherries;
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_COLLECT);
            }
            Destroy(collision.gameObject);
            cherries++;
            GameManager.Instance.UpdateCherries(cherries);
            Debug.Log(BaseManager<GameManager>.Instance.Cherries);
            collectCherryDelegate(cherries);                               //broadcast event
        }    
    }  
}
