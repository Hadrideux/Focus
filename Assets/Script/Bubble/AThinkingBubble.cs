using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AThinkingBubble : MonoBehaviour
{
    #region ATTRIBUTS

    [SerializeField] protected ETypeThink _typeThink = ETypeThink.NONE;
    [SerializeField] protected float _thinkSpeed = 0;
    [SerializeField] protected Transform _focusPosition = null;
    [SerializeField] protected Rigidbody _rb = null;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public ETypeThink TypeThink => _typeThink;

    public Transform FocusPosition => _focusPosition;

    public Rigidbody Rigidbody => _rb;

    #endregion PROPERTIES
    
    #region METHODES

    public abstract void Init(Transform target);

    #endregion METHODES

}
