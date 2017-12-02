using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [Header("Raycast")]
    public float rayDistance;
    private Ray drawRay;

    public GameObject enemySeek;

    public GameObject player;



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayCastLook();
    }

    void Update()
    {
        if (player.GetComponent<PlayerStats>().playerSneaky != 0)
        {
            rayDistance = player.GetComponent<PlayerStats>().playerSneaky;
            //Debug.Log("Player playerSneaky = " + player.GetComponent<PlayerStats>().playerSneaky);
            //Debug.Log("Enemy rayDistance = " + rayDistance);

            return;
        }
    }

    void RecalculateRay()
    {
        drawRay = new Ray(transform.position, transform.forward);
    }

    // OnDrawGizmos only runs in Scene window
    void OnDrawGizmos()
    {
        RecalculateRay();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(drawRay.origin, drawRay.origin + drawRay.direction * rayDistance);
    }

    void RayCastLook() // RayCast, if Enemy sees Player then Enemy seeks Player
    {
        RecalculateRay();
        RaycastHit rayHit;

        if (Physics.Raycast(drawRay, out rayHit, rayDistance))
        {
            /* Testing Raycast */
            //GameObject clone = Instantiate(testRaycast);

            //clone.transform.position = rayHit.point;
            /**************************************/

            if (enemySeek.GetComponent<PathFollowing>().target == null)
            {
                if (rayHit.collider.GetComponent<Movement>() != null) // Does raycast hit object with Movement script? (Player)
                {
                    //Debug.Log("Enemy sees Player!");

                    enemySeek.GetComponent<PathFollowing>().target = rayHit.collider.GetComponentInParent<Transform>(); // If so, Enemy target in Seek script is Transform (Movement script is in the Child) of raycast hit object!

                    //Debug.Log("Enemy Seek target = " + enemySeek.GetComponent<PathFollowing>().target);
                }
            }

            if (!rayHit.collider.GetComponent<Movement>() && enemySeek.GetComponent<PathFollowing>().target != null) // If the Enemy no longer sees the Player but still has Player targeted in Seek script:
            {
                
            }
        }
    }
}

