using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.persistentDataPath + "/Saves/";
    private static readonly string SAVE_FILE = "save.txt";
    public static void Init()
    {


        //Test to see if folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //create save folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }

        

    }

    public static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + SAVE_FILE, saveString);
    }

    public static string Load()
    {
        

        

        if(File.Exists(SAVE_FOLDER + SAVE_FILE))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + SAVE_FILE);
            return saveString;
        }
        else
        {
            return null;
        }
        
    }
}
