using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneManager : Singleton<SwitchSceneManager>
{
    private void Start()
    {
        CharacterManager.Instance.Init();
        ScoreManager.Instance.Init();
        GameManager.Instance.Init();
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene("ScenePomodoro");

    }

    public void LoadMainLevel()
    {
        SceneManager.LoadScene("SceneMainMenu");
    }

    public void LoadManagerLevel()
    {
        SceneManager.LoadScene("SceneManager");
    }
}