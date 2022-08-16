using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    // Loads Game Scene
    public void PlayButton(){
        SceneManager.LoadScene("Game");
    }

    // Loads Main Menu Screen
    public void MainMenuButton(){
        SceneManager.LoadScene("Main Menu");
    }

    // Quits Application
    public void QuitButton(){
        Application.Quit();
    }
}
