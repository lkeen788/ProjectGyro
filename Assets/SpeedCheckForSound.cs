using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedCheckForSound : MonoBehaviour
{
    public static SpeedCheckForSound _instance;

    public Rigidbody rb;
    public AudioSource audioSource;

    public float maxSpeed;
    public AnimationCurve volumeCurve;
    public AnimationCurve pitchCurve;

    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        var speed = rb.velocity.magnitude;
        //Debug.Log("speed= " + speed);

        // normalize speed into 0-1
        var scaledVelocity = Remap(Mathf.Clamp(speed, 0, maxSpeed), 0, maxSpeed, 0, 1);

        // set volume based on volume curve
        //audioSource.volume = volumeCurve.Evaluate(scaledVelocity);

        // set pitch based on pitch curve
        audioSource.pitch = pitchCurve.Evaluate(scaledVelocity);

        


    }

    public void StopSFX()
    {
        audioSource.Pause();
    }
    public void PlaySFX()
    {
        audioSource.UnPause();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contactCount == 1 && collision.collider.CompareTag("Wall"))
        {
            AudioManager.Instance.PlaySFX("HitWall");
        }
    }

    // https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
