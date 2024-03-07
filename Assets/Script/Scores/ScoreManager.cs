using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private int _score = 0;
    [SerializeField] private TextMeshProUGUI _text = null; //mettre dans le Score controller ? 
    public float ComputeScore()
    {
        return CharacterManager.Instance.GoodThinking.Count;
    }


}
