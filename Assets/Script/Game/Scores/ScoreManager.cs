using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{ 
    public void Init()
    {
        Debug.Log("ScoreManager Init");
    }

    public float ComputeScore()
    {
        return CharacterManager.Instance.GoodThinking.Count;
    }
}
