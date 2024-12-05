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

    public Vector3 start = (0.0f,0.5f,0.0f);
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth < 10)
        {
            playerLives = playerLives -1;
            playerHealth = 100;
            transform.position = start;
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

}
