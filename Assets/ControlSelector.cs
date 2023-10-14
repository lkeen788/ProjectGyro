using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSelector : MonoBehaviour
{
    GameObject loader;

    TouchControls touch;
    GyroControls gyro;

    bool gyroEnabled;

    private void Start()
    {
        touch = GetComponent<TouchControls>();
        gyro = GetComponent<GyroControls>();
    }

    // Update is called once per frame
    void Update()
    {
        loader = GameObject.Find("SceneLoader");

        if(loader != null)
        gyroEnabled = loader.GetComponent<SceneLoader>().GetGyroBool();

        
        if(gyroEnabled)
        {
            gyro.enabled = true;
            touch.enabled = false;
        }
        else
        {
            touch.enabled = true;
            gyro.enabled = false;
        }

    }
}
