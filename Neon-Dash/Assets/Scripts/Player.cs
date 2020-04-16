using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // ***Scene Change when health drop to 0 is moved to enemy and Laser scripts***

    // Player movement
    public float playerSpeed;
    
    // Player Dash
    public float dashSpeed;
    public float startDashTime;
    private float dashTime;

    public GameObject dashParticle;
    
    // audio
    public AudioClip dashSound;
    private AudioSource audioSource;

    
    // player's Health is 10 by default
    public int health = 10;
    
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        Vector2 moveInput = new  Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * playerSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0)
        {
            var position = transform.position;
            Instantiate(dashParticle, position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(dashSound,position, 0.5f);
            StartCoroutine(nameof(DashMove));
            dashTime = startDashTime;
        }

        else
        {
            dashTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    IEnumerator DashMove()
    {
        playerSpeed += dashSpeed;
        yield return new WaitForSeconds(0.3f);
        playerSpeed -= dashSpeed;
    }
}