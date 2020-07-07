using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverScreen;
  
    bool HasGameEneded = false;

    void Start()
    {
        gameoverScreen = GameObject.Find("GameOverCanavas");
        gameoverScreen.SetActive(true);
    }

    public void update()
    {
      
        if (HasGameEneded == false)
        {
            Time.timeScale = 0;
            HasGameEneded = true;
           // gameoverScreen.SetActive(true);
        }
        //gameoverScreen.SetActive(false);
       // Time.timeScale = 1;
    }


}


//public void ReturnToMainMenu()

//{
//    Time.timeScale = 1;
//    SceneManager.LoadScene("");
//}
//public void QuitGame()
//{
//    Time.timeScale = 1;
//    Application.Quit();
//}
