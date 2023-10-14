using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPos;
    private Quaternion rotX;
    private Quaternion rotZ;
    public float tiltSpeedModifierZ;
    public float tiltSpeedModifierY;

    public int ballForceModifier;


    float xRotation;
    float zRotation;
    //dev stuff
    public TextMeshProUGUI tiltspeedmod;
    public TextMeshProUGUI drag;
    public TextMeshProUGUI angularDrag;
    public TextMeshProUGUI rotationX;
    public TextMeshProUGUI rotationZ;

    // Update is called once per frame
    void Update()
    {
        //dev sensitivity testing


        //touch controls
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    //current method of rotation
                    //Vector3 rot = transform.localEulerAngles;
                    //rot.z += -touch.deltaPosition.x * tiltSpeedModifierZ * Time.deltaTime;
                    //rot.x += touch.deltaPosition.y * tiltSpeedModifierY * Time.deltaTime;
                    //transform.localEulerAngles = rot;

                    float xAxisRotation = touch.deltaPosition.y * tiltSpeedModifierY * Time.deltaTime;
                    float zAxisRotation = touch.deltaPosition.x * tiltSpeedModifierZ * Time.deltaTime;
                    xRotation -= zAxisRotation;
                    xRotation = Mathf.Clamp(xRotation, -10f, 10f);
                    zRotation -= xAxisRotation;
                    zRotation = Mathf.Clamp(zRotation, -10f, 10f);
                    transform.localRotation = Quaternion.Euler(-zRotation, 0f, xRotation);






                    //force ball to move in direction level is tilted toward
                    if (xRotation > 0)
                    {
                        GetComponent<Rigidbody>().AddForce(transform.right * ballForceModifier);
                    }
                    else if (xRotation < 0)
                    {
                        GetComponent<Rigidbody>().AddForce(-transform.right * ballForceModifier);
                    }

                    if (zRotation > 0)
                    {
                        GetComponent<Rigidbody>().AddForce(transform.forward * ballForceModifier);
                    }
                    else if (zRotation < 0)
                    {
                        GetComponent<Rigidbody>().AddForce(-transform.forward * ballForceModifier);
                    }

                    //rotX = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * tiltSpeedModifier * Time.deltaTime);
                    //transform.rotation *= rotX;
                    //rotZ = Quaternion.Euler(touch.deltaPosition.y * tiltSpeedModifier * Time.deltaTime, 0f, 0f);
                    //transform.rotation *= rotZ;
                    break;
            }

        }
        //else
        //{
        //    StartCoroutine(AnimateRotationTowards(transform, Quaternion.identity, 0.3f));
        //}

        //if(Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    StartCoroutine(AnimateRotationTowards(transform, Quaternion.identity, 0.2f));
        //}
    }

    private System.Collections.IEnumerator AnimateRotationTowards(Transform target, Quaternion rot, float dur)
    {
        float t = 0f;
        Quaternion start = target.rotation;
        while (t < dur)
        {
            target.rotation = Quaternion.Slerp(start, rot, t / dur);
            yield return null;
            t += Time.deltaTime;
        }
        target.rotation = rot;
    }


    //dev Commands
    //public void AddSensitivity()
    //{
    //    tiltSpeedModifier += 1f;
    //}
    //public void MinusSensitivity()
    //{
    //    tiltSpeedModifier -= 1f;
    //}

    //public void BallDefault()
    //{
    //    ball.GetComponent<Rigidbody>().mass = 10;
    //    ball.GetComponent<Rigidbody>().drag = 0;
    //    ball.GetComponent<Rigidbody>().angularDrag = 0;
    //}
    //public void AddDragToBall()
    //{
    //    ball.GetComponent<Rigidbody>().drag += 1;
    //}
    //public void AddAngularDrag()
    //{
    //    ball.GetComponent<Rigidbody>().angularDrag += 1;
    //}
}
