using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingBubbleController : AThinkingBubble
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
        transform.position = Vector3.MoveTowards(transform.position, _focusPosition.transform.position, _thinkSpeed *  Time.deltaTime);
    }

    #endregion Methodes

}
