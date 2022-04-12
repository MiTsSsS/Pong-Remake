using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject rightPaddle, leftPaddle;
    public GameState state;

    private int playerScore, aiScore = 0;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerScored(bool isHuman) { 
        if (isHuman)
        {
            playerScore++;

        }
        else {
            aiScore++;
            
        }

    }

    public enum GameState {
        Win,
        Lose,
        PlayerScored,
        AiScored

    }
}
