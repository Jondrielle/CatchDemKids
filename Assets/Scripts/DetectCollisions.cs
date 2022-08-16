using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.Events;


public class DetectCollisions : MonoBehaviour
{
    public UnityEvent updateScore;
    public UnityEvent cooldownTimer;
    public PlayerController player;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Child"){
            updateScore.Invoke();
        }
        else if(other.tag == "Powerup1"){
            player.IncreaseSpeed(5);
            cooldownTimer.Invoke();
        }
        else if(other.tag == "Powerup2"){
            player.IncreaseSpeed(15);
            cooldownTimer.Invoke();
        }
        
        Destroy(other.gameObject);
    }

}
