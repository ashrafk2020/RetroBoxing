using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGameManager : MonoBehaviour
{
    public static BoxGameManager Instance{get; private set;}
    public event EventHandler<PlayerScoreEventArgs> OnPlayersScoreUpdate;

    public event EventHandler<string> OnPlayerWins;
    int leftScore = 0;
    int rightScore = 0;

    [SerializeField] int gameEndScore = 10;

    public class PlayerScoreEventArgs : EventArgs
    {
       public int playerLeftScore;
       public int playerRightScore;

    }
    private void Awake()
    {
        Instance = this;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            leftScore++;
            rightScore++;
            OnPlayersScoreUpdate?.Invoke(this, new PlayerScoreEventArgs
            {
                playerLeftScore = leftScore,
                playerRightScore = rightScore

            }

            );
           
        }
    }

    public void UpdateAttackerScore(Fighter attacker)
    {
        if (attacker.GetPlayerLeft())
        {
            leftScore++;
        }
        else if (attacker.GetPlayerRight())
        {
            rightScore++;
        }
        OnPlayersScoreUpdate?.Invoke(this, new PlayerScoreEventArgs
        {
            playerLeftScore = leftScore,
            playerRightScore = rightScore

        });
        bool leftPlayerWinner = leftScore == gameEndScore;
        bool rightPlayerWinner= rightScore == gameEndScore;
        string winnerName = leftPlayerWinner == true? "left wins":"Right wins";
        if (leftPlayerWinner || rightPlayerWinner)
        {
            OnPlayerWins?.Invoke(this,"player side " + winnerName);
            //end game and restat positions
            //reset players scores and health
         
            // Debug.Log("plyer side " + winnerName);
        }

    }
}
