using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public Slider percentegeSlider;
    public Text percentegeText;
    public string sceneName;

    public void MoveScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsynchronus(sceneName));
        Time.timeScale = 1;
    }

    IEnumerator LoadAsynchronus(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            percentegeSlider.value = progress;
            percentegeText.text = "Loading Scene " + progress * 100f + "%";

            yield return null;
        }
    }
}
