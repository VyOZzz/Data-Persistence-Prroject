using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIManager : MonoBehaviour
{
    public static UIManager Instance; 
    [SerializeField] private TMP_InputField nameField;

     public TextMeshProUGUI bestScoreText;
     public GameObject Canvas;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if(nameField.text != "") {
            name = nameField.text;
            SceneManager.LoadScene(1);
            Canvas.SetActive(false);
        } else {
            Debug.LogWarning("Please enter a name!");
        }
        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
        
    }
}
