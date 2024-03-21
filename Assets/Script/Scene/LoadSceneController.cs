
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    public void LoadManagerScene()
    {
        SceneManager.LoadScene("SceneManager");
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
