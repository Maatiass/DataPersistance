using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string userName;
    public int highScore;
    public string highName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    
    public void save()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        data.highName = highName;
        data.highScore = highScore;
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highName = data.highName;   
            highScore = data.highScore; 
        }

    }

}

[System.Serializable]
public class SaveData
{
    public int highScore;
    public string highName;
}

