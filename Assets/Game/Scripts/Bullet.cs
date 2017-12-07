using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MazeWallPrefab") ||
            other.gameObject.name == "Wall" ||
            other.gameObject.CompareTag("Enemy") ||
            other.gameObject.CompareTag("Lootbox"))
        {
            Destroy(gameObject);
        }
    }
}
