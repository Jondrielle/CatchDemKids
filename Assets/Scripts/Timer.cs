using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public UnityEvent GameEnded;
    public int timerLimit;
    public int currentTime;

    void Start() {
       // currentTime = timerLimit;
        timerText.text = $"{currentTime}";
        StartCoroutine(TimerLimit());   
    }

    //
    IEnumerator TimerLimit(){
        while(timerLimit != 0){
            timerText.text = $"{timerLimit}";
            yield return new WaitForSecondsRealtime(1);
            timerLimit -= 1;    
        }
        timerText.text = $"{timerLimit}";
        GameEnded.Invoke();
    }


}
