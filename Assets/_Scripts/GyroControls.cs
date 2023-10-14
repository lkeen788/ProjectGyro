using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GyroControls : MonoBehaviour
{
    Vector3 rot;
    public float rotSpeedx;
    public float rotSpeedy;
    public GameObject ball;
    float axis1;
    float axis2;


    float xRotation;
    float zRotation;


    Vector3 startPos = new Vector3(0, 0, 0);

    void Start()
    {
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
        Input.gyro.enabled = true;

    }

    void Update()
    {
        //new clamped method
        float xAxisRotation = Input.gyro.rotationRate.x * rotSpeedx * Time.deltaTime;
        float zAxisRotation = Input.gyro.rotationRate.y * rotSpeedy * Time.deltaTime;
        xRotation -= zAxisRotation;
        xRotation = Mathf.Clamp(xRotation, -10f, 10f);
        zRotation -= xAxisRotation;
        zRotation = Mathf.Clamp(zRotation, -10f, 10f);
        transform.localRotation = Quaternion.Euler(zRotation, 0, xRotation);

        //current method
        //rot.x = -Input.gyro.rotationRateUnbiased.x;
        //rot.z = -Input.gyro.rotationRateUnbiased.y;
        //transform.Rotate(rot * rotSpeed * Time.deltaTime);

        //using quaternion
        //axis1 += -Input.gyro.rotationRate.x * rotSpeed * Time.deltaTime;
        //axis2 += -Input.gyro.rotationRate.y * rotSpeed * Time.deltaTime;

        //transform.rotation = Quaternion.Euler(axis1, 0, axis2);

    }

    public void ResetOrientation()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        ball.transform.position = new Vector3(ball.transform.position.x, 0.5f, ball.transform.position.z);
    }
}
