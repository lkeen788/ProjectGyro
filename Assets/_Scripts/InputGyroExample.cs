//Attach this script to a GameObject in your Scene.
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class InputGyroExample : MonoBehaviour
{
    Gyroscope m_Gyro;
    public Button btn;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        //transform.rotation = Quaternion.identity;
        

    }


    private void Update()
    {
        Vector3 localDown = Quaternion.Inverse(m_Gyro.attitude) * Vector3.down;

        float rollDegrees = Mathf.Asin(localDown.x) * Mathf.Rad2Deg;
        float pitchDegrees = Mathf.Atan2(localDown.y, localDown.z) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(rollDegrees, pitchDegrees, 0);
    }

    public void ResetOrientation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    //This is a legacy function, check out the UI section for other ways to create your UI
    void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        GUI.Label(new Rect(500, 300, 2000, 4000), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(500, 350, 2000, 4000), "Gyro attitude" + m_Gyro.attitude);
        GUI.Label(new Rect(500, 400, 2000, 4000), "Gyro enabled : " + m_Gyro.enabled);
        GUILayout.Label("iphone width/height: " + Screen.width + " / " + Screen.height);
    }
}