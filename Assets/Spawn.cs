using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = this.transform.position;

    }
    
}
