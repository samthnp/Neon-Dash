using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // ***Scene Change when health drop to 0 is moved to enemy and Laser scripts***

    // Player movement
    public float speed;
    
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // player's Health is 10 by default
    public int health = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new  Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}