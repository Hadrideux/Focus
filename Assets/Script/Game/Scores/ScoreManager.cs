using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private GameObject _endMenu = null;
    [SerializeField] private TextMeshProUGUI _scoreText = null;

    public GameObject EndMenu
    {
        get => _endMenu;
        set => _endMenu = value;
    }

    public TextMeshProUGUI ScoreText
    {
        get => _scoreText; 
        set => _scoreText = value;
    }

    public void Init()
    {
        Debug.Log("ScoreManager Init");
    }

    public float ComputeScore()
    {
        return CharacterManager.Instance.GoodThinking.Count;
    }
}
