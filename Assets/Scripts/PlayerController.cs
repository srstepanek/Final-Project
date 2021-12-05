using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 startPos;

    bool isActive = true;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();


        moveSpeed = 1f;
        jumpForce = 20f;
        isJumping = false;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.R))
            {
                LevelManager.instance.Restart();
            }
        }
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            {
                rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            }

            if (!isJumping && moveVertical > 0.1f)
            {
                rb2D.AddForce(new Vector2(0f, moveVertical * moveSpeed), ForceMode2D.Impulse);
            }
        }
        else
            rb2D.velocity = Vector2.zero;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

        //Pick Ups
        if (collision.gameObject.tag == "Coins")
        {
            LevelManager.instance.UpdateScore(1);
            LevelManager.instance.RemoveObject("Coin", collision.gameObject);
        }
        if (collision.gameObject.tag == "TimePickUp")
        {
           // LevelManager.instance.RemoveObject("TimePickUp", collision.transform.position);
            //Destroy(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
    }

    public void Play()
    {
        isActive = true;
    }

    public void Restart()
    {
        transform.position = startPos;
        isActive = false;
    }
}
