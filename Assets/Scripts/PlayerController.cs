using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 40.0f;
    public float xRange = 20;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }

    public void DisableMovement(){
        speed = 0f;
    }

    public void EnableMovement(){
        speed = 40.0f;
    }

    public void IncreaseSpeed(int valueIncrease){
        speed += valueIncrease;
    }

    public void ResetSpeed(){
        speed = 10f;
    }
}
