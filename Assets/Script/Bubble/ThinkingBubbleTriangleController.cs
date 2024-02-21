using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingBubbleTriangleController : AThinkingBubble
{
    #region Attributs


    #endregion Attributs

    #region Mono

    void Start()
    {

    }

    void Update()
    {
        UpdatePosition();
    }

    #endregion Mono

    #region Methodes

    public override void Init(GameObject target)
    {
        _focusPosition = target;
    }

    public override void UpdatePosition()
    {
       
    }

    #endregion Methodes


}
