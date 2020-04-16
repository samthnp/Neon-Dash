using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    
    public GameObject playerDash;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void FixedUpdate()
    {
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = 1;
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = 2;
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = 3;
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }

        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }

            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    Instantiate(playerDash, transform.position, Quaternion.identity);
                    rb.velocity = Vector2.left * dashSpeed;
                }

                else if (direction == 2)
                {
                    Instantiate(playerDash, transform.position, Quaternion.identity);
                    rb.velocity = Vector2.right * dashSpeed;
                }
                
                else if (direction == 3)
                {
                    Instantiate(playerDash, transform.position, Quaternion.identity);
                    rb.velocity = Vector2.up * dashSpeed;
                }
                
                else if (direction == 4)
                {
                    Instantiate(playerDash, transform.position, Quaternion.identity);
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
}
