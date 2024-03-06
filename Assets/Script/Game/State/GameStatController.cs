using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class GameStatController : MonoBehaviour
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
        _stateDic.Add(EGamePhase.REPOS, new ReposState());

        ChangeState(GameManager.Instance.CurrentGamePhase);

        foreach (KeyValuePair<EGamePhase, AGameState> kvp in _stateDic)
        {
            kvp.Value.Init(_gameController);
        }
    }

    public void Update()
    {
        CurrentGameState.UpdateState();
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

    #endregion METHODE
}
