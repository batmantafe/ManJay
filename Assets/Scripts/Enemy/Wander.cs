﻿using UnityEngine;
using System.Collections;

public class Wander : SteeringBehaviour
{
    public float offset = 10.0f;
    public float radius = 1.0f;
    public float jitter = 0.2f;

    private Vector3 targetDir;
    private Vector3 randomDir;

    public override Vector3 GetForce()
    {
        // Force starts at zero (no velocity)
        Vector3 force = Vector3.zero; // ... to hero

        /*

        -32767                  0                       32767
        |-----------------------|-----------------------|
                    |_______________________|
                            Random Range

        */

        // Randomize range between values
        float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
        float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);

        #region Calculate Random Direction
        // Create the random direction vector
        randomDir = new Vector3(randX, 0, randZ);

        // Normalize the random direction
        randomDir = randomDir.normalized;

        // Multiply jitter to randomDir
        randomDir *= jitter;
        #endregion

        #region Calculate Target Direction
        // Append target dir with randomDir
        targetDir += randomDir;

        // Normalize the target dir
        targetDir = targetDir.normalized;
        // targetDir.Normalize();

        // Amplify it by the radius
        targetDir *= radius;
        #endregion

        // Calculate seek position using targetDir
        Vector3 seekPos = transform.position + targetDir;
        seekPos += transform.forward.normalized * offset;
        
        #region Wander
        // Calculate direction
        Vector3 direction = seekPos - transform.position;

        // Is direction valid? (not zero)
        if (direction.magnitude > 0)
        {
            // Calculate force
            Vector3 desiredForce = direction.normalized * weighting;
            force = desiredForce - owner.velocity;
        }
        #endregion

        // Return the force ... Luke
        return force;
    }
}
