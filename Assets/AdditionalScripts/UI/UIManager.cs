﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            return;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
