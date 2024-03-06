using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class GameStatController : MonoBehaviour
{
    [SerializeField] private EGamePhase _currentGamePhase = EGamePhase.NONE;

    [SerializeField] private Dictionary<EGamePhase, AGameState> _stateDic = new Dictionary<EGamePhase, AGameState>();

    public EGamePhase CurrentGamePhase => _currentGamePhase;
    public AGameState CurrentGameState => _stateDic[CurrentGamePhase];

    // Start is called before the first frame update
    void Start()
    {
        _stateDic.Add(EGamePhase.NONE, new PomodoroState());
        _stateDic.Add(EGamePhase.NONE, new ReposState());
    }

    public void Update()
    {
        CurrentGameState.UpdateState();
    }

    public void ChangeState(EGamePhase nextState)
    {
        Debug.Log("Transition from : " + _currentGamePhase + " to " + nextState);

        CurrentGameState.Exit();
        _currentGamePhase = nextState;
        CurrentGameState.Enter();
    }
}
