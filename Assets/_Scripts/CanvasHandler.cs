using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    GameObject parentObj;
    GameObject gameHandler;

    public int currentLevel;
    public List<GameObject> content = new List<GameObject>();

    public Image banner;

    public GameObject creditPanel;
    public GameObject controlPanel;
    public GameObject levelSelectPanel;


    GameObject AudioManagerObj;
    public Slider _musicSlider, _sfxSlider;

    private void Update()
    {
        //checks to see if it is the main menu scene, if not disable menu canvas
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            //this canvas obj
            GetComponent<Canvas>().enabled = false;
        }
        else
        {
            //this canvas obj
            GetComponent<Canvas>().enabled = true;
        }
        gameHandler = GameObject.Find("GameHandler");
        AudioManagerObj = GameObject.Find("AudioManager");
        HandleContent();

        AudioManagerObj.GetComponent<AudioManager>().MusicVolume(_musicSlider.value);
        AudioManagerObj.GetComponent<AudioManager>().SFXVolume(_sfxSlider.value);

        
    }

    public void CreditWindow()
    {

        if (creditPanel != null)
        {
            bool isActive = creditPanel.activeSelf;
            creditPanel.SetActive(!isActive);

        }
    }

    public void ControlsWindow()
    {

        if (controlPanel != null)
        {
            bool isActive = controlPanel.activeSelf;
            controlPanel.SetActive(!isActive);

        }
    }

    public void LevelSelectWindow()
    {
        gameHandler.GetComponent<GameHandler>().Load();

        if (levelSelectPanel != null)
        {
            bool isActive = levelSelectPanel.activeSelf;
            levelSelectPanel.SetActive(!isActive);
            

        }
        

        if (banner != null)
        {
            bool isActive = banner.enabled;
            banner.enabled = !isActive;

        }
    }

    void HandleContent()
    {
        for (int i = 0; i <= currentLevel; i++)
        {
            content[i].SetActive(true);
        }

    }

    public int GetNumberOfButtons()
    {
        return currentLevel;
    }

    public void SetNumberOfButtons(int num)
    {
        currentLevel = num;
    }

    public void DeleteSaveFile()
    {
        gameHandler.GetComponent<GameHandler>().ResetSaveFile();
        gameHandler.GetComponent<GameHandler>().Load();
        ResetLevelButtons();
    }

    public void ResetLevelButtons()
    {
        foreach (GameObject item in content)
        {
            item.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DevPlayLevel()
    {
        SceneManager.LoadScene(20);
    }
}
