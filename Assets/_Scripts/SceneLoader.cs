using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;
using Unity.VisualScripting;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public int highestLevelReached;
    public bool tutorialComplete;
    public Scene currentScene;
    public GameObject levelControlsObj;
    public GameObject toggle;
    [SerializeField]bool gyroEnabled;
    bool tempBool;
    GameObject toggleText;

    //public List<Scene> completedLevels = new List<Scene>();


    //savesystem
    GameObject gameHandler;

    //dev
    public GameObject canvas;
    public TextMeshProUGUI texMeshPro;


    private void Start()
    {
        
        toggle.GetComponent<Toggle>().isOn = tempBool;
    }

    

    public void LoadTestScene()
    {
        SceneManager.LoadScene("Testing");
    }

    public void WinState()
    {
        SceneManager.LoadScene("MainMenuTest");
    }

    public void LoadNextLevel()
    {
        highestLevelReached = currentScene.buildIndex;
        SceneManager.LoadScene(currentScene.buildIndex + 1);
        gameHandler.GetComponent<GameHandler>().Save();
    }

    public void LoadMainMenuScene()
    {
        gameHandler.GetComponent<GameHandler>().Load();
        SceneManager.LoadScene("MenuGyro");
    }


    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void Update()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        gameHandler = GameObject.Find("GameHandler");
        texMeshPro = canvas.GetComponentInChildren<TextMeshProUGUI>();
        toggleText = GameObject.Find("ToggleText");

        //texMeshPro.text = SceneManager.GetActiveScene().name;

        currentScene = SceneManager.GetActiveScene();
        levelControlsObj = GameObject.FindGameObjectWithTag("LevelObj");

        if(toggle != null)
        {
            if (toggle.GetComponent<Toggle>().isOn)
            {
                gyroEnabled = true;
            }
            else
            {
                gyroEnabled = false;
            }
        }
        
        if(toggleText != null)
        {
            if (toggle.GetComponent<Toggle>().isOn)
            {
                toggleText.GetComponent<TextMeshProUGUI>().text = "ON";
            }
            else
            {
                toggleText.GetComponent<TextMeshProUGUI>().text = "OFF";
            }
        }

    }

    public int GetHighestReachedLevel()
    {
        return highestLevelReached;
    }
    public void SetLevelSelectButtons(int numOfLevels)
    {
        highestLevelReached = numOfLevels;
    }

    
    public bool GetGyroBool()
    {
        return gyroEnabled;
    }
    public void SetGyroControlToggle(bool gyroBool)
    {
        tempBool = gyroBool;
    }

}
