using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    public bool isInstructions;


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
            body.text = "This is the body text for highscores";
        }
    }
}
