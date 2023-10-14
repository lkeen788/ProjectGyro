using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject buttonOn;
    public GameObject buttonOff;
    public bool isButtonPressed;

    private void Start()
    {
        isButtonPressed = false;
        buttonOn.SetActive(false);
        buttonOff.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            buttonOn.SetActive(true);
            buttonOff.SetActive(false);
            isButtonPressed = true;
        }
    }
}
