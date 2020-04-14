using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Transform playerPosition;

    private Player player;

    public GameObject particlePlayerDamage;
    public GameObject particleEnemyDamage;
    
    public GameObject playerDefeatedParticle;
    
    // audio
    public AudioClip enemyExploded;
    public AudioClip enemyDeath;
    public AudioClip playerDefeatedSound;
    private AudioSource audioSource;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        audioSource = GetComponent<AudioSource>();
    }
    
    void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            // Play explode particle
            // Player audio
            // Then destroy the enemy object
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
            // Play particle then audio
            // Destroy both the particle and the enemy it hits
            var position = transform.position;
            Instantiate(particleEnemyDamage, position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemyDeath, position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        
        // Load new scene if player's health reaches 0
        
        if (player.health <= 0)
        {
            var position = transform.position;
            var particleSpawn = Instantiate(playerDefeatedParticle, position, Quaternion.identity);
            Instantiate(particleSpawn);
            AudioSource.PlayClipAtPoint(playerDefeatedSound, position, 0.1f);
            Invoke("LoadNewScene", 0.65f);
        }
    }
}
