using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchLaserGrid : MonoBehaviour
{

    public float speed;
    private Transform playerPosition;

    private Player player;

    public GameObject particlePlayerDamage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            player.health--;
            player.health--;
            player.health--;
            player.health--;
            player.health--;
            Instantiate(particlePlayerDamage, transform.position, Quaternion.identity);
            Debug.Log(player.health);
        }
    }
}