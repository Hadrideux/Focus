using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    #region ATTRIBUTS

    [SerializeField] private Dictionary<EGamePhase, AGameState> _stateDic = new Dictionary<EGamePhase, AGameState>();

    [SerializeField] private TimerController _timerController = null;
    #endregion ATTRIBUTS

    #region PROPERTIES

    public AGameState CurrentGameState { get { return _stateDic[GameManager.Instance.CurrentGamePhase]; } }

    #endregion PROPERTIES

    #region MONO

    // Start is called before the first frame update
    void Awake()
    {
        _stateDic.Add(EGamePhase.NONE, gameObject.AddComponent<DummyState>()); //TODO: Fix this piece of shit
        _stateDic.Add(EGamePhase.START, gameObject.AddComponent<StartState>());
        _stateDic.Add(EGamePhase.POMODORO, gameObject.AddComponent<PomodoroState>());
        _stateDic.Add(EGamePhase.INTERLUDE, gameObject.AddComponent<InterludeState>());
        _stateDic.Add(EGamePhase.REST, gameObject.AddComponent<RestState>());
        _stateDic.Add(EGamePhase.END, gameObject.AddComponent<EndState>());

        ChangeState(GameManager.Instance.CurrentGamePhase);

        foreach (KeyValuePair<EGamePhase, AGameState> kvp in _stateDic)
        {
            kvp.Value?.Init(_timerController);
        }
    }

    void Update()
    {
        CurrentGameState?.UpdateState();
    }

    #endregion MONO

    #region METHODE

    public void ChangeState(EGamePhase nextState)
    {
        Debug.Log("Transition from : " + GameManager.Instance.CurrentGamePhase + " to " + nextState);

        CurrentGameState?.Exit();
        GameManager.Instance.CurrentGamePhase = nextState;
        CurrentGameState?.Enter();
    }

    public void ChangeState()
    {
        EGamePhase nextState = EGamePhase.NONE;
        
        switch (GameManager.Instance.CurrentGamePhase)
        {
            //case EGamePhase.NONE:
            //    nextState = EGamePhase.START;
            //    break;

            case EGamePhase.START:
                nextState = EGamePhase.POMODORO;
                break;

            case EGamePhase.POMODORO:
                nextState = EGamePhase.INTERLUDE;
                break; 
            
            case EGamePhase.INTERLUDE:
                nextState = EGamePhase.REST;
                break;

            case EGamePhase.REST:
                nextState = EGamePhase.END;
                break;

            default:
                nextState = EGamePhase.START;
                break;
        }
        
        ChangeState(nextState);

        GameManager.Instance.TriggerPhaseChangeEvent();
    }

    #endregion METHODE
}

///
/// Revoir la changement de phase
/// Est-ce que les state "Start et End" doive hérité de AGameState
///