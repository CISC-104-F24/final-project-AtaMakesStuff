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

    public static int previousSceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
        newHealthPointsText = "" + playerHealth;
        healthDisplay.text = newHealthPointsText;

        if (playerLives < 1)
        {
            previousSceneNumber = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(3);
        }
    }

    public void loadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneNumber);
    }

}
