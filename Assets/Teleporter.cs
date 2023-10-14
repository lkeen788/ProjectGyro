using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleporterTarget; //position for the teleporter to send to
    public GameObject player; //player obj var

    private void Awake()
    {
        player = GameObject.Find("Sphere");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Teleport");
            player.transform.position = TeleporterTarget.transform.position;
        }
    }
}
