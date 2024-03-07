using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{ 
    public float ComputeScore()
    {
            return CharacterManager.Instance.GoodThinking.Count;
    }
    //ScoreManager.Instance.ComputeScore();

}
