using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Focus Type")]
    [SerializeField] private ETypeThink[] _thinkFocus = null;
    [SerializeField] private ETypeThink _currentFocus = ETypeThink.NONE;

    #endregion ATTRIBUTS

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
        SetFocusRequirement();
    }
    
    void OnTriggerEnter(Collider other)
    {
        AThinkingBubble thinkingBubble = other.GetComponentInParent<AThinkingBubble>();
        FocusStability(thinkingBubble);
    }
    public void OnTriggerExit(Collider other)
    {
        AThinkingBubble thinkingBubble = other.GetComponentInParent<AThinkingBubble>();
        FocusStability(thinkingBubble);
    }

    #endregion MONO

    #region METHODE

    private void FocusStability(AThinkingBubble thinkBubble)
    {
        switch (thinkBubble.TypeThink == _currentFocus)
        {
            case true:
                
                CharacterManager.Instance.GoodThinking.Add(thinkBubble);

                break;

            case false:
                
                CharacterManager.Instance.BadThinking.Add(thinkBubble);
                /*
                foreach (AThinkingBubble kvp in CharacterManager.Instance.BadThinking)
                {
                    CharacterManager.Instance.GoodThinking.Remove(kvp);
                }
                */
                break;

        }
    }

    private void SetFocusRequirement()
    {
        _currentFocus = _thinkFocus[Random.Range(0, _thinkFocus.Length - 1)];
    }

    
    #endregion METHODE
}
