﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float maxDistance = 5f;
    public bool updatePosition = true;
    public bool updateRotation = true;

    [HideInInspector]
    public Vector3 velocity;

    private Vector3 force;
    private List<SteeringBehaviour> behaviours;
    private NavMeshAgent nav;

    // Initialization
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
    }

    // Calculates all forces from attached SteeringBehaviours
    void ComputeForces()
    {
        // Reset force before calculation
        force = Vector3.zero;

        // Loop through all behaviours
        for (int i = 0; i < behaviours.Count; i++)
        {
            // Get current behaviour
            SteeringBehaviour b = behaviours[i];

            // Check if behaviour is active and enabled
            if (!b.isActiveAndEnabled)
            {
                // Skip over to next behaviour
                continue;
            }

            // Apply behaviour's force to our final force
            force += b.GetForce() * b.weighting;

            // Check if force has gone over maxSpeed
            if (force.magnitude > maxSpeed)
            {
                // Cap the force down to maxSpeed
                force = force.normalized * maxSpeed;

                // Exit for loop
                break;
            }
        }
    }

    // Applies the velocity to agent
    void ApplyVelocity()
    {
        // Increase velocity by force
        velocity += force * Time.deltaTime;

        // Update nav's speed to velocity
        nav.speed = velocity.magnitude;

        // Is there a velocity?
        if (velocity.magnitude > 0 && nav.updatePosition)
        {
            // Is the velocity over maxSpeed
            if (velocity.magnitude > maxSpeed)
            {
                // Cap velocity to maxSpeed
                velocity = velocity.normalized * maxSpeed;
            }

            // Predict the next position
            Vector3 pos = transform.position + velocity;

            // Perform NavMesh Sampling
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(pos, out navHit, maxDistance, -1))
            {
                // Set nav destination to navhit position
                nav.SetDestination(navHit.position);
            }
        }
    }

    // Update
    void Update()
    {
        nav.updatePosition = updatePosition;
        nav.updateRotation = updateRotation;
        ComputeForces();
        ApplyVelocity();
    }
}
