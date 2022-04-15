using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ball;
    private Rigidbody2D rb;

    float ballSpeed = 1.5f;
    //Vector3 direction = new Vector3(0.06f, 0.0f, 0.0f);

    private void launchBall()
    {
        int initialSide = Random.Range(0, 100);

        if(initialSide <= 49)
        {
            rb.AddForce(new Vector2(-300, 150) * ballSpeed);

        }

        else
        {
            rb.AddForce(new Vector2(300, -150) * ballSpeed);

        }
    }

    private void speedUp()
    {
        rb.velocity += new Vector2(6, 6);
        gameManager.GetComponent<GameManager>().speedUpPaddles();
        
    }

    private void resetBall()
    {
        rb.velocity = new Vector2(0, 0);
        ballSpeed = 2.0f;
        transform.position = Vector2.zero;
        gameManager.resetPaddles();
        Invoke("launchBall", 2);

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();
        Invoke("launchBall", 2);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D prb = collision.gameObject.GetComponent<Rigidbody2D>();
        BoxCollider2D bc = collision.gameObject.GetComponent<BoxCollider2D>();
        float ballYOffsetFromPaddle;

        if (collision.collider.CompareTag("Player")) {

            /*Vector2 vel;
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb.velocity = vel;*/
            ballSpeed += 0.35f;
            gameManager.playerScored();
            speedUp();
        }

        if (collision.collider.CompareTag("Score Field")) {
            if (collision.gameObject.name == "LeftScoreField") {
                //gameManager.playerScored();
                resetBall();

            }
            else {
                //gameManager.playerScored();
                resetBall();

            }
        }
    }
}
