using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public void OnClickedMenuButton()
    {
        GameManager.Instance.RestartGame();
    }
    public void OnClickedExitButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.EndGame();
        }
    }

}
