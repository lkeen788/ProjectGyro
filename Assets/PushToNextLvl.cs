using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushToNextLvl : MonoBehaviour
{
    public SceneLoader loader;

    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").SendMessage("PlaySFX");
        loader.LoadNextLevel();

    }
}
