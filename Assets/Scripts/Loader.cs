using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
     public static Loader Instance;
     private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);

        }
     }


    public void LoadScene(Scenes scene)
    {
        if(scene.ToString() == "SameLevel")
        {
            int getLevelIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(getLevelIndex);

        }
        else
        {
          SceneManager.LoadScene(scene.ToString());

        }


    }

    public void LoadSingleGame()
    {
        LoadScene(Scenes.SinglePlayer);
    }
    public void LoadMultiPlayerGame()
    {
        LoadScene(Scenes.TwoPlayers);
    }



    public enum Scenes
    {
        MainMenu,
        SameLevel,

        TwoPlayers,
        SinglePlayer

    }
}
