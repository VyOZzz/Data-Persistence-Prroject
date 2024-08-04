using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string namePlayer;
    public string bestName;
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
        LoadGameInfo();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int bestScore;
    }

    public void SaveGameInfo()
    {
        SaveData saveData = new SaveData();
        saveData.name = bestName;
        saveData.bestScore = bestScore;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadGameInfo() {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path)) {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.name;
            bestScore = data.bestScore;
        }
    }

    public void SetBestScore(int score) {
        if(score > bestScore) {
            bestScore = score;
            bestName = namePlayer;
            SaveGameInfo();
            UIManager.Instance.bestScoreText.text = "Best Score : " + bestName + " : " + bestScore;
        }
        Debug.Log("Score: " + score + "  Player: " + namePlayer);
    }
    public void UpdateHighScoreUI()
    {
        if (UIManager.Instance.bestScoreText != null)
        {
            UIManager.Instance.bestScoreText.text = "Best Score: " + bestName + ": " + bestScore;
        }
    }
}
