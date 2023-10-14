using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {

        GameObject[] levelManagers = GameObject.FindGameObjectsWithTag("LevelManager");

        if (levelManagers.Length > 1)
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (this.gameObject.CompareTag("GameplayCanvas"))
        {
            if(currentScene.name == "MainMenuTest")
            {
                gameObject.SetActive(false);
            }
        }
    }
}
