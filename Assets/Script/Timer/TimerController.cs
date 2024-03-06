using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerController : MonoBehaviour
{
    #region Attributs

    [SerializeField] private TextMeshProUGUI _timerText = null;
    [SerializeField] private float _timerDuration = 60f;

    #endregion Attributs

    #region Mono
    void Start()
    {
        StartCoroutine(TimerCountdown(_timerDuration));
    }

    void Update()
    {

    }
    #endregion Mono

    #region Methodes

    IEnumerator TimerCountdown(float duration)
    {
        float TotalTime = duration;
        while(TotalTime >= 0)
        {
            _timerText.text = FormatTime(TotalTime);

            yield return new WaitForSeconds(1f);

            TotalTime--;
        }

        TimerEnded();
    }

    string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        return string.Format("{0:00} : {1:00} ", minutes, seconds);
    }

    private void TimerEnded()
    {
        Debug.Log("Timer Ended!");
    }

    #endregion Methodes
}
