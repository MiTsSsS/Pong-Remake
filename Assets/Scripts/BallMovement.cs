using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ball;
    private Rigidbody2D rb;

    float ballSpeed = 10.0f;
    Vector3 direction = new Vector3(0.06f, 0.0f, 0.0f);

    private void launchBall()
    {
        int initialSide = Random.Range(0, 100);

        if(initialSide <= 49)
        {
            rb.AddForce(new Vector2(-300, 150));

        }

        else
        {
            rb.AddForce(new Vector2(300, -150));

        }

    }

    private void resetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = Vector2.zero;
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

            Vector2 vel;
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb.velocity = vel;
            //ballYOffsetFromPaddle = rb.transform.position.y - collision.transform.position.y;
            //Debug.Log(ballYOffsetFromPaddle);

        }

        if (collision.gameObject.name == "RightScoreField") {
            gameManager.playerScored(false);
            resetBall();

        }

        if (collision.gameObject.name == "LeftScoreField") {
            gameManager.playerScored(true);
            resetBall();

        }
    }
}
