using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text = null;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnChangePhase += NewScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        GameManager.Instance.OnChangePhase -= NewScore;
    }

    void OnApplicationQuit()
    {
        GameManager.Instance.OnChangePhase -= NewScore;
    }

    public void NewScore()
    {
    if (GameManager.Instance.CurrentGamePhase == EGamePhase.REST)
    _text.text = ScoreManager.Instance.ComputeScore().ToString();
    }
}
