using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Transform playerPosition;

    private Player player;

    public GameObject particlePlayerDamage;
    public GameObject particleEnemyDamage;
    
    // audio
    public AudioClip enemyExploded;
    public AudioClip enemyDeath;
    private AudioSource audioSource;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        audioSource = GetComponent<AudioSource>();
    }

    
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // enemy explode at player and damage them by 1 health
            player.health--;
            Debug.Log(player.health);
            var position = transform.position;
            Instantiate(particlePlayerDamage, position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemyExploded, position);
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
            // Player's projectile will damage enemy
            var position = transform.position;
            Instantiate(particleEnemyDamage, position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemyDeath, position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
