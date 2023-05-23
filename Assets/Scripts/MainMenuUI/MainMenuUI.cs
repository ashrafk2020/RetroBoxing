using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
      [SerializeField] Button singlePlayer;
    [SerializeField] Button localMultiplayer;
     private void Start() {
    
        singlePlayer.onClick.AddListener(()=>Loader.Instance.LoadScene(Loader.Scenes.SinglePlayer));
        localMultiplayer.onClick.AddListener(()=>Loader.Instance.LoadScene(Loader.Scenes.TwoPlayers));

    }

   
}
