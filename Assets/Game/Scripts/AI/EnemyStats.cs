using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth;
    public int enemyMaxHealth;

    public bool playerShootCheck;

    public GameObject player;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject eye3;

    // Use this for initialization
    void Start()
    {
        playerShootCheck = false;

        enemyHealth = 6;
        enemyMaxHealth = enemyHealth;
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
                //Destroy(gameObject);

                //gameObject.GetComponent<Flee>().target = player.GetComponent<Transform>();
                //gameObject.GetComponent<PathFollowing>().target = null;

                StartCoroutine("EnemyReset");
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
                    enemyMaxHealth = enemyHealth;

                    break;

                case 2:
                    enemyHealth = 5;
                    enemyMaxHealth = enemyHealth;

                    break;

                case 3:
                    enemyHealth = 4;
                    enemyMaxHealth = enemyHealth;

                    break;

                case 4:
                    enemyHealth = 3;
                    enemyMaxHealth = enemyHealth;

                    break;

                case 5:
                    enemyHealth = 2;
                    enemyMaxHealth = enemyHealth;

                    break;

                case 6:
                    enemyHealth = 1;
                    enemyMaxHealth = enemyHealth;

                    break;
            }

            //Debug.Log("player.playerHealthStat = " + player.GetComponent<PlayerStats>().playerHealthStat);
            //Debug.Log("enemyHealth = " + enemyHealth);

            playerShootCheck = true;
        }
    }

    IEnumerator EnemyReset() // Enemy flees from Player when Health below 0, then returns to Wander.
    {
        gameObject.GetComponent<Flee>().target = player.GetComponent<Transform>();
        gameObject.GetComponent<PathFollowing>().target = null;
        enemyHealth = enemyMaxHealth;

        eye1.GetComponent<Look>().enabled = false;
        eye2.GetComponent<Look>().enabled = false;
        eye3.GetComponent<Look>().enabled = false;

        yield return new WaitForSeconds(enemyMaxHealth);

        gameObject.GetComponent<Flee>().target = null;

        eye1.GetComponent<Look>().enabled = true;
        eye2.GetComponent<Look>().enabled = true;
        eye3.GetComponent<Look>().enabled = true;
    }


}
