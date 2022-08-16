using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void PlayButton(){
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton(){
        Application.Quit();
    }
}
