using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject chooseLevelPanel, 
                      optionsPanel, 
                      creditsPanel,
                      storePanel;
     
    public GameObject buttons;
    public void Play()
    {
        chooseLevelPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        storePanel.SetActive(false);
        buttons.SetActive(false);
    }
    public void Options()
    {
        chooseLevelPanel.SetActive(false);
        optionsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        storePanel.SetActive(false);
        buttons.SetActive(false);
    }
    public void Credits()
    {
        chooseLevelPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        storePanel.SetActive(false);
        buttons.SetActive(false);
    }
    public void Store()
    {
        chooseLevelPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        storePanel.SetActive(true);
        buttons.SetActive(false);
    }
    public void Back()
    {
        chooseLevelPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        storePanel.SetActive(false);
        buttons.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
