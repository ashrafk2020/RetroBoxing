using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerLeftScore;
    [SerializeField] TextMeshProUGUI playerRightScore;
    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshProUGUI winMessage;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;


    

    private void Start() {
        BoxGameManager.Instance.OnPlayersScoreUpdate += BoxGameManager_OnPlayersScoreUpdate;
        BoxGameManager.Instance.OnPlayerWins += BoxGameManager_OnPlayerWins;
        restartButton.onClick.AddListener(()=>Loader.Instance.LoadScene(Loader.Scenes.SameLevel));
        mainMenuButton.onClick.AddListener(()=>Loader.Instance.LoadScene(Loader.Scenes.MainMenu));

    }

    private void BoxGameManager_OnPlayerWins(object sender, string winnerName)
    {
        winScreen.SetActive(true);
        winMessage.text = winnerName;
    }

    private void BoxGameManager_OnPlayersScoreUpdate(object sender, BoxGameManager.PlayerScoreEventArgs args)
    {
        playerLeftScore.text = args.playerLeftScore.ToString();
        playerRightScore.text = args.playerRightScore.ToString();

    }
}
