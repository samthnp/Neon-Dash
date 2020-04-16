using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTouchLaserGrid : MonoBehaviour
{
    private Transform playerPosition;

    private Player player;
    private GameObject playerGameObject;

    // Particle
    public GameObject playerDamagedParticle;
    public GameObject playerDefeatedParticle;
    
    // audio
    public AudioClip playerDamageSound;
    public AudioClip playerDefeatedSound;
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        
        audioSource = GetComponent<AudioSource>();
    }
    
    void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            var position = transform.position;
            AudioSource.PlayClipAtPoint(playerDamageSound, position, 0.35f);
            Instantiate(playerDamagedParticle, position, Quaternion.identity);
            Debug.Log(player.health);
        }



        // load new scene if player dies
        if (other.CompareTag("Laser"))
        {
            if (player.health <= 0)
            {
                var position = transform.position;
                var particleSpawn = Instantiate(playerDefeatedParticle, position, Quaternion.identity);
                Instantiate(particleSpawn);
                AudioSource.PlayClipAtPoint(playerDefeatedSound, position, 0.35f);
                playerGameObject.SetActive(false);
                Invoke(nameof(LoadNewScene), 1f);
            }
        }
    }
}