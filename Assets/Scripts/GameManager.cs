using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject rightPaddle, leftPaddle;
    private int playerScore;
    public Text leftScore;

    private void Awake()
    {
        instance = this;
    }

    public void resetPaddles()
    {
        rightPaddle.transform.position = new Vector3(9, 0, -1);
        leftPaddle.transform.position = new Vector3(-9, 0, -1);
        rightPaddle.GetComponent<PaddleController>()._speed = 6.0f;
        leftPaddle.GetComponent<PaddleController>()._speed = 6.0f;
        playerScore = 0;
        leftScore.text = "0";

    }

    public void speedUpPaddles()
    {
        rightPaddle.GetComponent<PaddleController>()._speed += 0.5f;
        leftPaddle.GetComponent<PaddleController>()._speed += 0.5f;
    }

    public void playerScored() 
    { 
        playerScore += 100;
        leftScore.text = playerScore.ToString();
        //resetPaddles();

    }
}
