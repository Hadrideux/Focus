using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndState : AGameState
{
    public override void Init(TimerController controller)
    {
        _timerController = controller;
    }

    public override void Enter()
    {
        Time.timeScale = 0;

        ScoreManager.Instance.EndMenu.SetActive(true); //TODO: NullReferenceException        
    }

    public override void Exit()
    {
        
    }

    public override void UpdateState()
    {

    }
}

///
/// UI de fin ne s'affiche pas 
///
