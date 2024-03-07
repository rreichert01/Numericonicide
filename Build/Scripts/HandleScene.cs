using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenStartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenLevel2Scene()
    {
        SceneManager.LoadScene(2);
    }
    public void OpenLevel3Scene()
    {
        SceneManager.LoadScene(3);
    }
    public void OpenLevel4Scene()
    {
        SceneManager.LoadScene(6);
    }
}

