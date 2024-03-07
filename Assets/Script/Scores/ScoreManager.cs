using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private int _score = 0;
    [SerializeField] private TextMeshProUGUI _text = null; //mettre dans le Score controller ? 
    private void IncrementScore(int amount)
    {
        _score += amount;
        Debug.Log("Score actuel : " + _score);
    }


}
