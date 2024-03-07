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
        ScoreManager.Instance.ComputeScore();
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
                Debug.Log("Good Focus : Bubble : " + thinkBubble.TypeThink + "\nBad Focus : " + _currentFocus);
                CharacterManager.Instance.GoodThinking.Add(thinkBubble);
                break;

            case false:
                Debug.Log("Bad Focus : Bubble : " + thinkBubble.TypeThink + "\nGood Focus : " + _currentFocus);
                CharacterManager.Instance.BadThinking.Add(thinkBubble);
                break;

        }
    }

    private void SetFocusRequirement()
    {
        _currentFocus = _thinkFocus[Random.Range(0, _thinkFocus.Length - 1)];
    }

    #endregion METHODE
}
