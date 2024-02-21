using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AThinkingBubble : MonoBehaviour
{
    #region ATTRIBUTS

    [SerializeField] protected ETypeThink _typeThink = ETypeThink.NONE;
    [SerializeField] protected float _thinkSpeed = 0;
    [SerializeField] protected GameObject _focusPosition = null;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public ETypeThink TypeThink => _typeThink;

    public GameObject FocusPosition => _focusPosition;

    #endregion PROPERTIES
    
    #region METHODES
    public abstract void UpdatePosition();

    public abstract void Init(GameObject target);

    #endregion METHODES

}
