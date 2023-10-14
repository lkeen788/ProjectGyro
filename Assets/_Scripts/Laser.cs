using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Button buttonScript;
    bool isActive;
    public GameObject laser;

    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = buttonScript.isButtonPressed;
        if (isActive)
        {
            laser.SetActive(false);
        }
    }
}
