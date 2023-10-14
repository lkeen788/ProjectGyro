using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public Button buttonScript;
    bool isActive;

    void Update()
    {
        isActive = buttonScript.isButtonPressed;
        if (isActive)
        {
            this.gameObject.SetActive(true);
        }
    }
}
