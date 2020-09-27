using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Default : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public GameManager gameManager;
    public float rotationSpeed;
    private float jumpCounter;
    public float jumpingForce;
    public int speed;
    public int speedBoost;
    public float minLean, maxLean;
    public GameObject flashPanel;

    public AudioSource jumpSound,
                       damageSound,
                       boostSound,
                       speedPickup,
                       healthPickup,
                       coinPickup;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Movement();
    }

    public void Movement() 
    {
        transform.position += transform.right * Time.deltaTime * speed;
        jumpCounter += Time.deltaTime;

        if (Input.GetKey(KeyCode.D) && (transform.rotation.eulerAngles.y < 40 || (transform.eulerAngles.y > 140)))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);                       
        }
        else if (Input.GetKey(KeyCode.A) && (transform.rotation.eulerAngles.y < 120 || (transform.eulerAngles.y > 310)))
        {           
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }               
        if (Input.GetKey(KeyCode.Space) && jumpCounter >= 1)
        {
            jumpSound.Play();
            myRigidbody.AddForce(new Vector3(0, jumpingForce, 0), ForceMode.Impulse);
            jumpCounter = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && gameManager.canBoost == true)
        {
            StartCoroutine(SpeedBuff());          
            boostSound.Play();
        }                
    }

    IEnumerator SpeedBuff() 
    {
        speed = 80;
        gameManager.currentBoosts--;

        yield return new WaitForSeconds(0.8f);

        speed = 50;       
    }
    IEnumerator DamageFlashScreen() 
    {
        flashPanel.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        flashPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            gameManager.currentHealth--;
            StartCoroutine(DamageFlashScreen());
            damageSound.Play();
        }

        if (other.gameObject.layer == 10) 
        {          
            if (other.gameObject.CompareTag("Speed"))
            {
                speedPickup.Play();
            }
            if (other.gameObject.CompareTag("Health"))
            {
                healthPickup.Play();
            }
            if (other.gameObject.CompareTag("Coin"))
            {
                coinPickup.Play();
            }                      
        }
        if (other.gameObject.layer == 11)
        {
            SceneManager.LoadScene("Level I");
        }
    }
}
