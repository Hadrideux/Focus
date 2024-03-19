using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndState : AGameState
{
    [SerializeField] private GameObject _scoreUI = null;
    [SerializeField] private TextMeshProUGUI _scoreText = null;

    public override void Init(TimerController controller)
    {
        _timerController = controller;
    }

    public override void Enter()
    {
        Time.timeScale = 0;

        _scoreUI.SetActive(true);

        Debug.Log("End");

        if(ScoreManager.Instance.ComputeScore() ==  0)
        {
            _scoreText.text = "0";
        }
        else
        {
            _scoreText.text = "1";
        }
        
    }

    public override void Exit()
    {
        
    }

    public override void UpdateState()
    {
        Debug.Log("End Update");
    }
}

///
/// UI de fin ne s'affiche pas 
///
