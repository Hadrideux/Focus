using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterludeState : AGameState
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
        //GameManager.Instance.CurrentGamePhase = EGamePhase.REST;
    }

    public override void UpdateState()
    {
        _timerController.Timer();
    }
}
