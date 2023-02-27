using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SetText : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    public bool isInstructions;
    public ScoreList scoreList;
    public UnityEvent clearText;

    public void SetTitle(bool isInstructions){
        if(isInstructions == true){
            title.text = "Instructions";
        }
        else {
            title.text = "Highscores";
        }
    }

    public void SetBody(bool isInstructions){
        if(isInstructions == true){
            body.text = "This is the body text for instructions";
        }
        else {
            foreach(int score in scoreList.scores)
            {
                body.text += $"ABC {score} \n";
            }
        }
    }

    public void ClearBody()
    {
        body.text = "";
    }
}
