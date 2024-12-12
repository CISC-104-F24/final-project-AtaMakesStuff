using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Collisions : MonoBehaviour
{
    public int playerHealth = 100;

    public int healthChange = 10;

    public string newHealthPointsText;

    public TextMeshProUGUI healthDisplay;

    public int playerLives = 3;

    public int livesChange = 1;

    public string newLivesText;

    public TextMeshProUGUI livesDisplay;

    public GameObject purple; 

    public GameObject gameOver; 

    public GameObject titleScreenButton;

    public GameObject titleScreenText; 

    public GameObject retryButton;

    public GameObject retryText; 

    public GameObject healthText;

    public GameObject healthNumbers;

    public GameObject livesText;

    public GameObject livesNumbers;

    public GameObject flag1;

    public GameObject flag2;

    public GameObject flag3;

    public GameObject instructions1;

    public GameObject instructions2;

    public GameObject instructions3;

    private Rigidbody myRigidbody; 

    // Start is called before the first frame update
    void Start()
    {
        purple.SetActive(false);
        gameOver.SetActive(false);
        titleScreenButton.SetActive(false);
        titleScreenText.SetActive(false);
        retryButton.SetActive(false);
        retryText.SetActive(false);
        instructions2.SetActive(false);
        instructions3.SetActive(false);
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth < 10)
        {
            livesChanger();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            playerHealth = playerHealth - 10;
            newHealthPointsText = "" + playerHealth;
            healthDisplay.text = newHealthPointsText;
        }
    }

    private void livesChanger()
    {
        playerLives = playerLives -1;
        newLivesText = "" + playerLives;
        livesDisplay.text = newLivesText;
        playerHealth = 100;
        transform.position = new Vector3(0f,0.5f,0f);
        transform.rotation = Quaternion.identity;
        newHealthPointsText = "" + playerHealth;
        healthDisplay.text = newHealthPointsText;

        if (playerLives < 1)
        {
            purple.SetActive(true);
            gameOver.SetActive(true);
            titleScreenButton.SetActive(true);
            titleScreenText.SetActive(true);
            retryButton.SetActive(true);
            retryText.SetActive(true);
            healthText.SetActive(false);
            healthNumbers.SetActive(false);
            livesText.SetActive(false);
            livesNumbers.SetActive(false);
            flag1.SetActive(false);
            flag2.SetActive(false);
            flag3.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Instructions1"))
        {
            instructions2.SetActive(true);
        }
        
        if(other.gameObject.CompareTag("Instructions2"))
        {
            instructions3.SetActive(true);
        }

        if(other.gameObject.CompareTag("KillBox"))
        {
            livesChanger();
        }
    }

}
