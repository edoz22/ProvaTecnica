using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPc : MonoBehaviour
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
