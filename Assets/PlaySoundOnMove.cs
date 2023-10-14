using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnMove : MonoBehaviour
{
    public AudioSource audioSource;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.angularVelocity.x > .01)
        {
            audioSource.mute = false;
        }
        else if(rb.angularVelocity.x < .01)
        {
            audioSource.mute = true;
        }
        
    }
}
