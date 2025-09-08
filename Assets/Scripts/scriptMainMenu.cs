using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("sceneLevel1");    //Go to Level 1.
    }
    public void exitGame()
    {
        Debug.Log("Quitting game...");                  //Send a message that you are exitting the game.   
        Application.Quit();                             //Quit Game.
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("sceneMainMenu");
    }
}
