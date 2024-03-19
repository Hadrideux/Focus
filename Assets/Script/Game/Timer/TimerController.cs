using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Controller")]
    [SerializeField] private GameStateController _stateController = null;

    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _timerText = null;
    [SerializeField] private float _phaseDelay = 0;
    [SerializeField] private float _timeStamp = 0;

    #endregion ATTRIBUTS

    #region MONO

    void Start()
    {
        _phaseDelay = GameManager.Instance.TimerPomodoro;
    }

    void Update()
    {
    }

    #endregion MONO

    #region METHODES
   
    private string FormatTime(float time)
    {
        time = _phaseDelay - time;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        return string.Format("{0:00} : {1:00} ", minutes, seconds);
    }

    public void Timer()
    {
        _timeStamp += Time.deltaTime;
        if (_timeStamp >= _phaseDelay)
        {
            _stateController.ChangeState();

            _phaseDelay = GameManager.Instance.CurrentDelay;
            _timeStamp = 0;
        }

        _timerText.text = FormatTime(_timeStamp);
    }

    #endregion METHODES
}
