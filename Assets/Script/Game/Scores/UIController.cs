using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _endMenu = null;
    [SerializeField] private TextMeshProUGUI _scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.EndMenu = _endMenu;
        ScoreManager.Instance.EndMenu.SetActive(false);

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
        if (GameManager.Instance.CurrentGamePhase == EGamePhase.END)
            _scoreText.text = ScoreManager.Instance.ComputeScore().ToString();
    }
}
