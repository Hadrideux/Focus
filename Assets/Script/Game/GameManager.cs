using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region ATTRIBUTS

    [SerializeField] private EGamePhase _currentGamePhase = EGamePhase.NONE;

    [SerializeField] private int _scoreThink = 0;

    [SerializeField] private float _timerPomodoro = 0;
    [SerializeField] private float _timerRepos = 0;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public EGamePhase CurrentGamePhase
    {
        get => _currentGamePhase;
        set => _currentGamePhase = value;
    }

    public float TimerPomodoro => _timerPomodoro;
    public float TimerRepos => _timerRepos;

    #endregion PROPERTIES
}
