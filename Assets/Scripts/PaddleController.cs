using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject _paddle;
    private Rigidbody2D rb;

    //public ChosenSide _chosenSide = ChosenSide.LeftSide;
    public float _startingPositionX = -9.0f;
    public float _speed = 6.0f;
    public float upperYBound = 4.24f;
    public float lowerYBound = -4.24f;
    //private Vector2 upperBoundVect = new Vector2(rb.transform.position.x, upperYBound);

    Vector2 calculatePosition(bool _isUp)   {
        Vector2 tempVect = new Vector2(0.0f, _speed * 0.050f);
        Vector2 finalVect;
        float currentY = rb.transform.position.y;
        float newY;

        if (_isUp)
            newY = currentY + tempVect.y;

        else
            newY = currentY - tempVect.y;

        finalVect = new Vector2(0.0f, newY);
        return finalVect;

    }

    public enum PaddleSide {
        LeftSide,
        RightSide

    };

    // Start is called before the first frame update
    void Start()
    {
        rb = _paddle.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))  {
            rb.MovePosition(calculatePosition(true));

        }

        if(Input.GetKey(KeyCode.DownArrow))  {
            rb.MovePosition(calculatePosition(false));

        }

    }
}
