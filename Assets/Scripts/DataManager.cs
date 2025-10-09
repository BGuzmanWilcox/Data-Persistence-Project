using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string userName;
    public int highScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetUsername(string username)
    {
        userName = username;
    }

    public void SetBestScore(int score)
    {
        highScore = score;
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;

        public int highScore;
    }

    public void SaveBestData(string username, int highScore)
    {
        SaveData data = new SaveData();

        data.userName = userName;

        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile,json", json);

    }

    public void LoadBestData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data =JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;

            highScore = data.highScore;
        }
    }
}
