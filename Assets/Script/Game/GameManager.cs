using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region ATTRIBUTS

    [Header("Game Phase")]
    [SerializeField] private EGamePhase _currentGamePhase = EGamePhase.NONE;

    [Header("Score Phase")]
    [SerializeField] private int _scoreThink = 0;

    [Header("Timer Phase")]
    [SerializeField] private float _timerPomodoro = 0;
    [SerializeField] private float _timerRest = 0;
    [SerializeField] private float _timerInterlude = 0;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public EGamePhase CurrentGamePhase
    {
        get => _currentGamePhase;
        set => _currentGamePhase = value;
    }

    public float TimerPomodoro => _timerPomodoro;

    public float CurrentDelay
    {
        get
        {
            if (CurrentGamePhase == EGamePhase.POMODORO)
                return _timerPomodoro;
            else if (CurrentGamePhase == EGamePhase.INTERLUDE)
                return _timerInterlude;
            else
                return _timerRest;
        }
    }

    #endregion PROPERTIES

    #region EVENTS

    private event Action _onChangePhase = null;
    public event Action OnChangePhase
    {
        add
        {
            _onChangePhase -= value;
            _onChangePhase += value;
        }
        remove
        {
            _onChangePhase -= value;
        }
    }

    #endregion EVENTS

    public void TriggerPhaseChangeEvent()
    {
        if (_onChangePhase != null)
        {
            _onChangePhase();
        }
    }
}
