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
}

