using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AThinkingBubble : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Init")]
    [SerializeField] protected Transform _focusPosition = null;
    [SerializeField] protected Rigidbody _rb = null;

    [Header("Type")]
    [SerializeField] protected ETypeThink _typeThink = ETypeThink.NONE;

    [Header("Movement")]
    [SerializeField] protected float _thinkSpeed = 0;
    [SerializeField] protected Vector3 _escapeDir = Vector3.zero;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public ETypeThink TypeThink => _typeThink;

    public Transform FocusPosition => _focusPosition;

    #endregion PROPERTIES

    #region MONO
    private void Start()
    {
        GameManager.Instance.OnChangePhase += EscapeDirection;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnChangePhase -= EscapeDirection;
    }
    private void OnApplicationQuit()
    {
        GameManager.Instance.OnChangePhase -= EscapeDirection;
    }

    #endregion MONO

    #region METHODES

    public abstract void Init(Transform target);

    public abstract void EscapeDirection();

    #endregion METHODES

}
