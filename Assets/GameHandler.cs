using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class GameHandler : MonoBehaviour
{

    public GameObject loader;
    public GameObject canvasHandler;

    private void Awake()
    {
        loader = GameObject.Find("SceneLoader");
        canvasHandler = GameObject.Find("Canvas");

        SaveSystem.Init();

        if (!File.Exists(Application.persistentDataPath + "/Saves/save.txt"))
        {
            File.Create(Application.persistentDataPath + "/Saves/save.txt");
            Debug.Log("NEW SAVE FILE CREATED!");
            return;
        }
        else
        {
            Debug.Log("File exists at: " + Application.persistentDataPath + "/Saves/save.txt");
            Load();
            return;
        }

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        int completedLevels = loader.GetComponent<SceneLoader>().GetHighestReachedLevel();
        bool gyroEnabled = loader.GetComponent<SceneLoader>().GetGyroBool();

        SaveObject saveObject = new SaveObject
        {
            completedLevels = completedLevels,
            gyroEneabled = gyroEnabled,
        };

        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        Debug.Log("Saved!");
    }

    public void ResetSaveFile()
    {
        int completedLevels = loader.GetComponent<SceneLoader>().GetHighestReachedLevel();

        SaveObject saveObject = new SaveObject
        {
            completedLevels = 0,
        };

        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        Debug.Log("Save File Reset!!!");
    }

    public void Load()
    {
        string saveString = SaveSystem.Load();
        if(saveString != null)
        { 
            Debug.Log("Loaded: " + saveString);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            loader.GetComponent<SceneLoader>().SetLevelSelectButtons(saveObject.completedLevels);
            canvasHandler.GetComponent<CanvasHandler>().SetNumberOfButtons(saveObject.completedLevels);
            loader.GetComponent<SceneLoader>().SetGyroControlToggle(saveObject.gyroEneabled);
        }
        else
        {
            Debug.Log("NO SAVE!");
        }
    }

    private class SaveObject
    {
        public int completedLevels;
        public bool gyroEneabled;
    }

}
