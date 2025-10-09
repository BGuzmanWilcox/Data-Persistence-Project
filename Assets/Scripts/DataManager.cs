using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string userName;
    public string bestUsername;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;

        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetUsername(string username)
    {
        userName = username;
    }
    public void SetBestUsername(string username)
    {
        bestUsername = username;
    }

    public void SetBestScore(int score)
    {
        bestScore = score;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestUsername;

        public int bestScore;
    }

    public void SaveBestData(string bestUser, int bestScore)
    {
        SaveData data = new SaveData();

        data.bestUsername = bestUser;

        data.bestScore = bestScore;

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

            bestUsername = data.bestUsername;

            bestScore = data.bestScore;
        }
    }
}
