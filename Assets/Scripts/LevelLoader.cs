using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }    
    public void LoadAboutMenu()
    {
        SceneManager.LoadScene("About");
    }
    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }


}
