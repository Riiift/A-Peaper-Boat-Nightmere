using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource HealthSound;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        int rotationSpeed = 220;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        HealthSound.Play();
        gameManager.currentHealth++;
        Destroy(gameObject);
    }
}
