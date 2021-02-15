using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpaSpawner : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] powerUp;
    public float spawnTime = 7f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int powerUpIdx = Random.Range(0, 2);

        Instantiate(powerUp[powerUpIdx], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
