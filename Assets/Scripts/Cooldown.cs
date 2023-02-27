using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Cooldown : MonoBehaviour
{
    public int coolDownLimit;
    public Slider barCoolDown;
    public UnityEvent disablePowerUp;
    public float valueDifference = 0.1f;
    
    void Start() {
        // SET VALUE TO 0 
        barCoolDown.value = 0;
    }

    /*
       RESET COOLDOWN BAR TO 1 AND 
       START IMPLEMENTATION
    */
    public void StartCountDown(){
        barCoolDown.value = 1;
        StartCoroutine(CoolerCountDown());
        StartCoroutine(BarCoolDown());
    }

    /*
        WAIT TIL COOLDOWN IS AT 
        0 THEN DISABLE POWERUP EFFECT
    */
    IEnumerator CoolerCountDown(){
        yield return new WaitForSecondsRealtime(coolDownLimit);
        disablePowerUp.Invoke();
    }

    /*
        COOLDOWN SLIDER UPDATED WITH 
        COOLDOWN TIMER
    */
    IEnumerator BarCoolDown(){
        while(barCoolDown.value != 0){
            yield return new WaitForSecondsRealtime(1);
            barCoolDown.value -= valueDifference;
        }
    }

    public void SetEmpty()
    {
        StopAllCoroutines();
        barCoolDown.value = 0;
    }
}
