using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") >0f)
        {
            rb.velocity =new Vector2(speed,rb.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        rb.velocity= new Vector2(x,rb.velocity.y);
    }

}
