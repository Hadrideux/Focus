using UnityEngine;

public class GameController : MonoBehaviour
{
    #region ATTRIBUTS

    #endregion ATTRIBUTS

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion MONO

    #region METHODES

    public void ChangePhase(EGamePhase newPhase)
    {
       switch (GameManager.Instance.CurrentGamePhase)
       {
            case EGamePhase.POMODORO :
                GameManager.Instance.CurrentGamePhase = EGamePhase.REPOS;

                Debug.Log(GameManager.Instance.CurrentGamePhase);
                break;

            case EGamePhase.REPOS:
                GameManager.Instance.CurrentGamePhase= EGamePhase.POMODORO;

                Debug.Log(GameManager.Instance.CurrentGamePhase);
                break;
       }
    }

    #endregion METHODES
}
