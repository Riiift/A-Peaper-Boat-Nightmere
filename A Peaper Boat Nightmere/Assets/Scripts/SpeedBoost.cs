using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource boostSound;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        int rotationSpeed = 220;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            boostSound.Play();
            Destroy(gameObject);
            gameManager.currentBoosts++;
        }        
    }
}
