using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int playerHealth;
    public int playerMana, playerStamina, playerSpeedStat, playerSneakyStat, playerShoot;
    public float playerSneaky;

    public GameObject customiseManager;

    [Header("Values")]
    public float[] speedValues;
    public float[] sneakyValues;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            playerHealth = customiseManager.GetComponent<CustomiseSet>().healthStat;
            playerMana = customiseManager.GetComponent<CustomiseSet>().manaStat;
            playerStamina = customiseManager.GetComponent<CustomiseSet>().staminaStat;
            playerSpeedStat = customiseManager.GetComponent<CustomiseSet>().speedStat;
            playerSneakyStat = customiseManager.GetComponent<CustomiseSet>().sneakyStat;
            playerShoot = customiseManager.GetComponent<CustomiseSet>().shootStat;

            SetValues();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetValues()
    {
        gameObject.GetComponent<Movement>().speed = speedValues[playerSpeedStat - 1];
        Debug.Log("playerSpeedStat = " + playerSpeedStat);
        Debug.Log("Player Movement Speed = " + gameObject.GetComponent<Movement>().speed);

        playerSneaky = sneakyValues[playerSneakyStat - 1];
        Debug.Log("playerSneaky = " + playerSneaky);
    }
}
