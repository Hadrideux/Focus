using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour 
{
    private event Action _timeOut = null;
    private event Action _targetClick = null;
    private event Action _targetTimerEnd = null;
    private event Action _targetMiss = null;
    private event Action _onAllTargetsDestroyed = null;

    public event Action TimeOut
    {
        add
        {
            _timeOut -= value;
            _timeOut += value;
        }
        remove
        {
            _timeOut -= value;
        }
    }
    public event Action Miss
    {
        add
        {
            _targetMiss -= value;
            _targetMiss += value;
        }
        remove
        {
            _targetMiss -= value;
        }
    }

    public event Action TargetClick
    {
        add 
        {
            _targetClick -= value;
            _targetClick += value;
        }
        remove 
        { 
            _targetClick -= value;
        }
    }

    public event Action TargetTimerEnd
    {
        add
        {
            _targetTimerEnd -= value;
            _targetTimerEnd += value;
        }

        remove
        {
            _targetTimerEnd -= value;
        }
    }

    public event Action OnAllTargetsDestroyed { add { _onAllTargetsDestroyed += value; } remove { _onAllTargetsDestroyed -= value; } }


    public void TimeFinish()
    {
        if (_timeOut != null)
        {
            _timeOut();
        }
    }
   
    public void TargetDestroy()
    {
        _targetClick?.Invoke(); //Safe invoke
    }

    public void TargetEnd()
    {
        _targetTimerEnd?.Invoke(); //Safe invoke
    }
    public void TargetMiss()
    {
        _targetMiss?.Invoke(); //Safe invoke
    }

    public void AllTargetsDestroyed() {
        _onAllTargetsDestroyed?.Invoke(); //Safe invoke
    }
}
