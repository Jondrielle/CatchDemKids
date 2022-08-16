using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cooldown : MonoBehaviour
{
    public int coolDownLimit;
    public UnityEvent disablePowerUp;

    public void StartCountDown(){
        StartCoroutine(CoolerCountDown());
    }

    IEnumerator CoolerCountDown(){
        yield return new WaitForSecondsRealtime(coolDownLimit);
        disablePowerUp.Invoke();
    }
}
