using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer masterVolume;
    public GameObject PauseMenuUI;
    public GameObject systemMenuUI;
    public GameObject gameMenuUI;
    public bool gamePaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void MasterVolume(float volume)
    {
        masterVolume.SetFloat("mVolume", Mathf.Log10(volume) * 20);
    }
    public void Resume()
    {
        gameMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        systemMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
        gamePaused = true;
    }
    public void BackToPause()
    {
        gamePaused = true;
        systemMenuUI.SetActive(false);
        gameMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }
    public void Game()
    {
        gamePaused = true;
        gameMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }
    public void System()
    {
        gamePaused = true;
        systemMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }   
}
