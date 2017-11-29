﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector3 size = new Vector3(50f, 20f, 100f);

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, size);
    }

    // Adjusts the position to constrain it within size
    public Vector3 GetAdjustedPos(Vector3 incomingPos)
    {
        Vector3 pos = transform.position;
        Vector3 halfSize = size * 0.5f;

        // Is incomingPos outside the positive Z?
        if (incomingPos.z > pos.z + halfSize.z)
        {
            incomingPos.z = pos.z + halfSize.z;
        }

        // Is incomingPos outside the negative Z?
        if (incomingPos.z < pos.z - halfSize.z)
        {
            incomingPos.z = pos.z - halfSize.z;
        }

        // Is incomingPos outside the positive X?
        if (incomingPos.x > pos.x + halfSize.x)
        {
            incomingPos.x = pos.x + halfSize.x;
        }

        // Is incomingPos outside the negative X?
        if (incomingPos.x < pos.x - halfSize.x)
        {
            incomingPos.x = pos.x - halfSize.x;
        }

        // Is incomingPos outside the positive Y?
        if (incomingPos.y > pos.y + halfSize.y)
        {
            incomingPos.y = pos.y + halfSize.y;
        }

        // Is incomingPos outside the negative Y?
        if (incomingPos.y < pos.y - halfSize.y)
        {
            incomingPos.y = pos.y - halfSize.y;
        }

        // Returns the adjusted incomingPos (feeds it back into this Function again at top)
        return incomingPos;
    }
}

