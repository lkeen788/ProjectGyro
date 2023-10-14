using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    GameObject loader;
    public int level;
    public int currentLevel;
    public TextMeshProUGUI textMeshProUGUI;

    public GameObject settingsPanel;

    public GameObject pausePanel;

    //savesystem
    GameObject gameHandler;

    

    private void Start()
    {
        
        loader = GameObject.Find("SceneLoader");
        gameHandler = GameObject.Find("GameHandler");


        if (loader != null)
        {
            currentLevel = loader.GetComponent<SceneLoader>().highestLevelReached;
        }

        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = level.ToString();
        }
    }

    private void Update()
    {
        if(loader != null)
        {
            currentLevel = loader.GetComponent<SceneLoader>().highestLevelReached;

        }
    }

    public void OpenScene()
    {
        gameHandler.GetComponent<GameHandler>().Save();
        SceneManager.LoadScene("Level " + level.ToString());
        GameObject.FindGameObjectWithTag("Player").SendMessage("PlaySFX");
        AudioManager.Instance.PlayMusic("Vintage");
        
    }

    public void OpenCurrentUnlockedLevel()
    {
        gameHandler.GetComponent<GameHandler>().Save();
        SceneManager.LoadScene("Level " + (currentLevel + 1).ToString());
    }


    //DEV
    public void LoadTestScene()
    {
        SceneManager.LoadScene("Testing");
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MenuGyro");
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").SendMessage("PlaySFX");
        AudioManager.Instance.PlayMusic("Dream");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void PausePanel()
    {

        if (pausePanel != null)
        {
            bool isActive = pausePanel.activeSelf;
            pausePanel.SetActive(!isActive);


        }

        
    }
}
