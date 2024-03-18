using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    #region ATTRIBUTS

    [SerializeField] private Dictionary<EGamePhase, AGameState> _stateDic = new Dictionary<EGamePhase, AGameState>();

    [SerializeField] private GameController _gameController = null;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public AGameState CurrentGameState => _stateDic[GameManager.Instance.CurrentGamePhase];

    #endregion PROPERTIES

    #region MONO

    // Start is called before the first frame update
    void Start()
    {

        _stateDic.Add(EGamePhase.POMODORO, new PomodoroState());
        _stateDic.Add(EGamePhase.INTERLUDE, new InterludeState());
        _stateDic.Add(EGamePhase.REST, new RestState());

        ChangeState(GameManager.Instance.CurrentGamePhase);

        foreach (KeyValuePair<EGamePhase, AGameState> kvp in _stateDic)
        {
            kvp.Value.Init();
        }
    }

    void Update()
    {
        CurrentGameState.UpdateState();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnChangePhase -= ChangeState;
    }
    private void OnApplicationQuit()
    {
        GameManager.Instance.OnChangePhase -= ChangeState;
    }

    #endregion MONO

    #region METHODE

    public void ChangeState(EGamePhase nextState)
    {
        Debug.Log("Transition from : " + GameManager.Instance.CurrentGamePhase + " to " + nextState);

        CurrentGameState.Exit();
        GameManager.Instance.CurrentGamePhase = nextState;
        CurrentGameState.Enter();
    }

    public void ChangeState()
    {
        EGamePhase nextState = EGamePhase.NONE;
        
        switch (GameManager.Instance.CurrentGamePhase)
        {
            case EGamePhase.POMODORO:
                nextState = EGamePhase.INTERLUDE;
                break; 
            
            case EGamePhase.INTERLUDE:
                nextState = EGamePhase.REST;
                break;

            case EGamePhase.REST:
                
                break;            
        }
        
        ChangeState(nextState);

        GameManager.Instance.TriggerPhaseChangeEvent();
    }

    #endregion METHODE
}
