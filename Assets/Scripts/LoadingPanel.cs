using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    public TextMeshProUGUI loadingPercentText;
    public Slider loadingSlider;
    private void OnEnable()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Level1");
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            loadingSlider.value = asyncOperation.progress;
            loadingPercentText.SetText($"LOADING SCENE:{asyncOperation.progress * 100}%");
            if (asyncOperation.progress >= 0.9f)
            {
                loadingSlider.value = 1f;
                loadingPercentText.SetText("Press any key to continue");
                if (Input.anyKeyDown)
                {
                    asyncOperation.allowSceneActivation = true;
                    if (UIManager.HasInstance)
                    {
                        UIManager.Instance.ActiveGamePanel(true);
                        UIManager.Instance.ActiveLoadingPanel(false);
                    }
                    if (UIManager.HasInstance)
                    {
                        GameManager.Instance.StartGame();
                    }
                }    
            }
            yield return null;

        }
       
    }    
}