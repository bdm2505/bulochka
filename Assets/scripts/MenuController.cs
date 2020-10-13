using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Score()
    {

    }
    public void Settings()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
