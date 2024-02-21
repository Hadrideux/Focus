using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AThinkingBubble : MonoBehaviour
{
    #region ATTRIBUTS

    protected ETypeThink _typeThink = ETypeThink.NONE;
    [SerializeField] protected float _thinkSpeed = 0;
    [SerializeField] protected GameObject _focusPosition = null;

    #endregion ATTRIBUTS

    #region METHODE
    public abstract void UpdatePosition();

    public abstract void Init(GameObject target);

    #endregion METHODE

}
