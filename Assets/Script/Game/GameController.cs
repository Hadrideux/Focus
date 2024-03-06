using UnityEngine;

public class GameController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.CurrentGamePhase = EGamePhase.POMODORO;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhase()
    {
       switch (GameManager.Instance.CurrentGamePhase)
       {
            case EGamePhase.POMODORO :
                Debug.Log(GameManager.Instance.CurrentGamePhase);
                break;

            case EGamePhase.REPOS:
                Debug.Log(GameManager.Instance.CurrentGamePhase);
                break;
       }
    }


}
