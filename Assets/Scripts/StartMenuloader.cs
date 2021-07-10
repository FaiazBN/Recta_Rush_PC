using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuloader : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Game 1");
    }


}
