using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class UiMenuManager : MonoBehaviour
{

    public TMP_InputField userName;

    public void StartButton()
    {
        SceneManager.LoadScene(1);

        DataManager.Instance.LoadBestData();
    }

    public void QuitButton()
    {
#if UNITY_EDITOR

        EditorApplication.EnterPlaymode();
#else
        Application.Quit();
#endif

    }
    
    public void ReadStringInput()
    {
        if (userName != null) 
        { 
        DataManager.Instance.SetUsername(userName.text);
        }
    }
}
