using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    // Player health
    // Player movement
    // Scene Change when health drop to 0

    public float speed;
    
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // player's HP is 10 by default
    public int health = 10;
    
    // particle
    public GameObject playerDefeatedParticle;
    
    // audio
    public AudioClip playerDefeatedSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        Vector2 moveInput = new  Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        
        // load new scene if player dies
        if (health <= 0)
        {
            var position = transform.position;
            var particleSpawn = Instantiate(playerDefeatedParticle, position, Quaternion.identity);
            Instantiate(particleSpawn);
            AudioSource.PlayClipAtPoint(playerDefeatedSound, position, 0.1f);
           Invoke("LoadNewScene", 0.65f);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}