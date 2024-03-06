using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    #region ATTRIBUTS

    [SerializeField] private List<AThinkingBubble> _goodThinking = null;
    [SerializeField] private List<AThinkingBubble> _badThinking = null;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public List<AThinkingBubble> GoodThinking
    {
        get => _goodThinking;
        set
        {
            _goodThinking = value;
            Debug.Log("Good Think : " + _goodThinking.Count);
        }
    }

    public List<AThinkingBubble> BadThinking
    {
        get => _badThinking;
        set
        {
            _badThinking = value;
            Debug.Log("Bad Think : " + _badThinking.Count);
        }
    }

    #endregion PROPERTIES
}
