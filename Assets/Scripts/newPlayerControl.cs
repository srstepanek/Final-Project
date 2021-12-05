using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class newPlayerControl : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] public float speed;
    [SerializeField] public float jump;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded == true)
           Jump();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

}
