using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIActivating : MonoBehaviour
{
    public GameObject uiObject;

    public void EnableUI(){
        uiObject.SetActive(true);
    }

    public void DisableUI(){
        uiObject.SetActive(false);
    }
}
