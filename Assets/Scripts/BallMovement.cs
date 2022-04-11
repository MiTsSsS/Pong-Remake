using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody2D rb;


    float ballSpeed = 1.0f;
    Vector3 direction = new Vector3(0.1f, 0.0f, 0.0f);
    
    private void launchBall()
    {
        int initialSide = Random.Range(0, 100);

        if(initialSide <= 49)
        {
            //Launch ball on left side

        }

        else
        {
            //Launch ball on right side

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(direction);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftPaddle") {
            direction.x = 0.1f;
            //Debug.Log("Left");

        }

        else if (collision.gameObject.name == "RightPaddle") {
            direction.x = -0.1f;
            //Debug.Log("Right");

        }

    }
}
