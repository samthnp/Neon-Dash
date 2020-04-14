using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPoint : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnSpots;

    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public GameObject particleEnemySpawn;


    private void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            int randomPosition = Random.Range(0, spawnSpots.Length);
            Instantiate(particleEnemySpawn, spawnSpots[randomPosition].position, Quaternion.identity);
            Instantiate(enemy, spawnSpots[randomPosition].position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
