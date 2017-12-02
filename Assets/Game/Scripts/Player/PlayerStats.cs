using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int playerHealthStat;
    public int playerMana, playerStamina, playerSpeedStat, playerSneakyStat, playerShoot;
    public float playerSneaky, playerHealth;

    public GameObject customiseManager;

    [Header("Values")]
    public float[] speedValues;
    public float[] sneakyValues;

    // Use this for initialization
    void Awake()
    {
        
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            //Debug.Log("playerSneaky in PlayerStats before = " + playerSneaky);

            SetValues();

            SetPlayerHealth();

            //Debug.Log("playerSneaky in PlayerStats after = " + playerSneaky);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetValues()
    {
        playerHealthStat = customiseManager.GetComponent<CustomiseSet>().healthStat;
        Debug.Log("playerHealthStat = " + playerHealthStat);

        playerMana = customiseManager.GetComponent<CustomiseSet>().manaStat;
        playerStamina = customiseManager.GetComponent<CustomiseSet>().staminaStat;
        playerSpeedStat = customiseManager.GetComponent<CustomiseSet>().speedStat;
        playerSneakyStat = customiseManager.GetComponent<CustomiseSet>().sneakyStat;
        playerShoot = customiseManager.GetComponent<CustomiseSet>().shootStat;

        gameObject.GetComponent<Movement>().speed = speedValues[playerSpeedStat - 1];
        //Debug.Log("playerSpeedStat = " + playerSpeedStat);
        //Debug.Log("Player Movement Speed = " + gameObject.GetComponent<Movement>().speed);

        playerSneaky = sneakyValues[playerSneakyStat - 1];
        //Debug.Log("playerSneaky = " + playerSneaky);
    }

    void SetPlayerHealth()
    {
        switch(playerHealthStat)
        {
            case 1:
                playerHealth = 1;
                break;

            case 2:
                playerHealth = 2;
                break;

            case 3:
                playerHealth = 3;
                break;

            case 4:
                playerHealth = 4;
                break;

            case 5:
                playerHealth = 5;
                break;

            case 6:
                playerHealth = 6;
                break;
        }
    }

    void OnCollisionEnter (Collision other)
    {
        if(other.collider.CompareTag("Enemy"))
        {
            playerHealth = playerHealth - (1 * Time.deltaTime);
            Debug.Log("playerHealth = " + playerHealth);

            if (playerHealth <= 0)
            {
                SceneManager.LoadScene("Customise");
            }
        }
    }
}
