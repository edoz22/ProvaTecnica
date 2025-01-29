using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasVr : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
