using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth;

    public bool playerShootCheck;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        playerShootCheck = false;

        enemyHealth = 6;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerShoot();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (enemyHealth == 1)
            {
                Destroy(gameObject);
            }

            else
            {
                enemyHealth = enemyHealth - 1;
                //Debug.Log("enemyHealth = " + enemyHealth);
            }
        }
    }

    void CheckPlayerShoot()
    {
        if(playerShootCheck == false)
        {
            switch (player.GetComponent<PlayerStats>().playerShoot)
            {
                case 1:
                    enemyHealth = 6;

                    break;

                case 2:
                    enemyHealth = 5;

                    break;

                case 3:
                    enemyHealth = 4;

                    break;

                case 4:
                    enemyHealth = 3;

                    break;

                case 5:
                    enemyHealth = 2;

                    break;

                case 6:
                    enemyHealth = 1;

                    break;
            }

            //Debug.Log("player.playerHealthStat = " + player.GetComponent<PlayerStats>().playerHealthStat);
            //Debug.Log("enemyHealth = " + enemyHealth);

            playerShootCheck = true;
        }
    }
}
