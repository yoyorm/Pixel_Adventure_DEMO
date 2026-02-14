using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : BaseUI<MainMenu>
{
    
    public void StartGame()
    {
        System.GC.Collect();
        SceneManager.LoadScene("Map1");
    }

    public void Settings()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
