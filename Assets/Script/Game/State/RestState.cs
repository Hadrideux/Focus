using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : AGameState
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
        //GameManager.Instance.CurrentGamePhase = EGamePhase.END;
    }

    public override void UpdateState()
    {
        _timerController.Timer();   
    }
}
