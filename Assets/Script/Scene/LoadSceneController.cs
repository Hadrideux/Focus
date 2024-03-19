
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    public void LoadScene()
    {
        SwitchSceneManager.Instance.LoadManagerLevel();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainScene()
    {
        SwitchSceneManager.Instance.LoadMainLevel();
    }

    public void RestartScene()
    {
        SwitchSceneManager.Instance.LoadGameLevel();
    }
}
