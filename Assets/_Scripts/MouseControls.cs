using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MouseControls : MonoBehaviour
{
    public float tiltSpeedModifier;

    public void Start()
    {
        // Confines the cursor
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        Vector3 rot = transform.localEulerAngles;
        rot.z += -Input.GetAxis("Horizontal") * tiltSpeedModifier * Time.deltaTime;
        rot.x += Input.GetAxis("Vertical") * tiltSpeedModifier * Time.deltaTime;
        transform.localEulerAngles = rot;

        if (Input.GetMouseButton(0))
        {
            rot.z += -Input.GetAxis("Mouse X") * tiltSpeedModifier * Time.deltaTime;
            rot.x += Input.GetAxis("Mouse Y") * tiltSpeedModifier * Time.deltaTime;
            transform.localEulerAngles = rot;
        }
        

        

    }

    

}

