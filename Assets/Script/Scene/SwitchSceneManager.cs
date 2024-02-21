using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGameLevel()
    {
        SceneManager.LoadScene("PomodoroScene");
    }
}
