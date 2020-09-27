using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Default defaultScript;
    public Text timeText, coinText; 
    public int currentCoins;
    private float timer;
    public GameObject DeathScreenUI;
    private Scene currentScene;

    public RawImage[] health;
    public int currentHealth;
    public int totalhealth = 3;


    public RawImage[] boost;
    public int currentBoosts;
    public int boostCounter;
    public int totalBoosts = 3;
    public bool canBoost = false;

    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            defaultScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Default>();
        }
        currentBoosts = 0;
        currentHealth = 3;
    }
    void Update()
    {
        coinText.text = "x" + currentCoins;    
        TimerDisplay();
        SpeedBoost();
        HealthDisplay();
        SpeedBoostDisplay();     
    }
    public void TimerDisplay()
    {
        if (timeText != null)
        {
            timer += Time.deltaTime;
            timeText.text = timer.ToString("00.00"); 
        }
    }
    public void Volume(float volume)
    {                
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
    public void SpeedBoost()
    {
        if (currentBoosts <= 0)
        {
            canBoost = false;
        }
        if (currentBoosts > 0 || currentBoosts == 3)
        {
            canBoost = true;
        }
    }
    public void Retry()
    {
        currentScene = SceneManager.GetActiveScene();

        if (DeathScreenUI.activeSelf)
        {
            Time.timeScale = 1f;
            currentHealth = 3;
            SceneManager.LoadScene(currentScene.buildIndex);
            DeathScreenUI.SetActive(false);
        }
    }
    public void SpeedBoostDisplay()
    {
        if (currentBoosts > 3)
        {
            currentBoosts = 3;
        }
        //remplazar con un for
        switch (currentBoosts)
        {
            case 0:
                boost[0].color = Color.black;
                boost[1].color = Color.black;
                boost[2].color = Color.black;   
                break;
            case 1:
                boost[0].color = Color.white;
                boost[1].color = Color.black;
                boost[2].color = Color.black;
                break;
            case 2:
                boost[0].color = Color.white;
                boost[1].color = Color.white;
                boost[2].color = Color.black;
                break;
            case 3:
                boost[0].color = Color.white;
                boost[1].color = Color.white;
                boost[2].color = Color.white;
                break;
        }
    }
    public void HealthDisplay()
    {
        if (currentHealth > 3)
        {
            currentHealth = 3;
        }
        //remplazar con un for
        switch (currentHealth)
        {
            case 0:
                DeathScreenUI.SetActive(true);
                Time.timeScale = 0f;
                defaultScript.flashPanel.SetActive(false);
                break;
            case 1:
                health[0].color = Color.white;
                health[1].color = Color.black;
                health[2].color = Color.black;
                break;
            case 2:
                health[0].color = Color.white;
                health[1].color = Color.white;
                health[2].color = Color.black;
                break;
            case 3:
                health[0].color = Color.white;
                health[1].color = Color.white;
                health[2].color = Color.white;
                break;
        }
    }         
}

