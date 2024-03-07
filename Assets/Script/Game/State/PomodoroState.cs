using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PomodoroState : AGameState
{
    public override void Init(GameController controller)
    {
       _gameController = controller;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void UpdateState()
    {
        //MeshChangeState(GameManager.Instance.NextState);
    }
}
