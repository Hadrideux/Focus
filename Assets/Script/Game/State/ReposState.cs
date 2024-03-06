using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposState : AGameState
{
    public override void Enter()
    {
        _gameController.ChangePhase();
    }

    public override void Exit()
    {

    }

    public override void Init(GameController controller)
    {
        _gameController = controller;
    }

    public override void UpdateState()
    {

    }
}
