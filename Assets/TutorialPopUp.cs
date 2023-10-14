using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPopUp : MonoBehaviour
{
    public GameObject mazeObj;
    public GameObject tutorialPanel;
    GameObject LevelManager;

    bool keepTutClosed;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.Find("SceneLoader");
        mazeObj = GameObject.Find("5x5 Level");
        tutorialPanel = GameObject.Find("Tutorial Panel");
        //mazeObj.GetComponent<TouchControls>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialPanel != null)
        {
            keepTutClosed = LevelManager.GetComponent<SceneLoader>().tutorialComplete;
            if (keepTutClosed)
            {
                tutorialPanel.SetActive(false);
            }


            if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space))
            {
                tutorialPanel.SetActive(false);
                //mazeObj.GetComponent<TouchControls>().enabled = true;
                this.enabled = false;

                LevelManager.GetComponent<SceneLoader>().tutorialComplete = true;
            }
        }
    }

}
