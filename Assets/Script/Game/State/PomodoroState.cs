using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PomodoroState : AGameState
{
    public override void Init(TimerController controller)
    {
        _timerController = controller;
    }
    public override void Enter()
    {

    }

    public override void Exit()
    {
        //GameManager.Instance.CurrentGamePhase = EGamePhase.INTERLUDE;
    }

    public override void UpdateState()
    {
        _timerController.Timer();
    }
}
