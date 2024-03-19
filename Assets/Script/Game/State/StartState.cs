using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : AGameState
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
        //GameManager.Instance.CurrentGamePhase = EGamePhase.POMODORO;
    }

    public override void UpdateState()
    {

    }
}
