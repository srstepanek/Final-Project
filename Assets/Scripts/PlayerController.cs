using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 startPos;

    bool isActive = true;

    private Rigidbody2D body;
    [SerializeField] public float speed;
    [SerializeField] public float jump;
    private bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

        
        UpdateMoveSpeeds();
        grounded = false;

        startPos = transform.position;

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (Input.GetKeyDown(KeyCode.W) && body.velocity.y == 0)
            {
                Jump();
                Debug.Log("Jump");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                LevelManager.instance.Restart();
            }
        }
        else
            body.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Platform")
        //{
        //    grounded = true;
        //    Debug.Log("Update");
        //}

        if (collision.gameObject.tag == "EndPoint")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        //Pick Ups
        if (collision.gameObject.tag == "Coins")
        {
            LevelManager.instance.UpdateScore(1 * (int)UpgradeMenuScript.instance.getMod("CoinMod"));
            LevelManager.instance.RemoveObject("Coin", collision.gameObject);
        }
        if (collision.gameObject.tag == "TimePickUp")
        {
            LevelManager.instance.RemoveObject("Time", collision.gameObject);
            LevelManager.instance.timePickUp(5);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        grounded = false;
    }

    public void Play()
    {
        UpdateMoveSpeeds();
        isActive = true;
    }

    public void Restart()
    {
        transform.position = startPos;
        isActive = false;
    }

    void UpdateMoveSpeeds()
    {
        speed = UpgradeMenuScript.instance.getMod("Speed");
        jump = UpgradeMenuScript.instance.getMod("Jump");
    }
}
