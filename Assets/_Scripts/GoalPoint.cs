using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalPoint : MonoBehaviour
{
    public SceneLoader loader;
    public GameObject pointLight;
    public GameObject gameWinScreen;



    bool atMax;
    public float interval;

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        atMax = true;
    }

    private void Update()
    {

        float tempRangeVal = pointLight.GetComponent<Light>().range;

        if (atMax)
        {
            DecreaseLight();
            if(tempRangeVal <= 1)
            {
                atMax = false;
            }
        }
        else
        {
            IncreaseLight();
            if (tempRangeVal >= 2)
            {
                atMax = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Win");
            GameObject.FindGameObjectWithTag("Player").SendMessage("StopSFX");
            //Debug.Log("You Win!");
            gameWinScreen.SetActive(true);
            Time.timeScale = 0;
            
            //loader.LoadNextLevel();


        }
    }

    void DecreaseLight()
    {
        pointLight.GetComponent<Light>().range -= interval * Time.deltaTime;
    }
    void IncreaseLight()
    {
        pointLight.GetComponent<Light>().range += interval * Time.deltaTime;
    }

    

}
