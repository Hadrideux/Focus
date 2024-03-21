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

    [Header("Anim and Sound")]
    [SerializeField] protected AnimationController _Animationcontroller = null;
    [SerializeField] protected SoundController _soundController = null;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public ETypeThink TypeThink => _typeThink;

    public Transform FocusPosition => _focusPosition;

    #endregion PROPERTIES

    #region MONO

    //public void Start()
    //{
    //    GameManager.Instance.OnChangePhase += EscapeDirection;
    //}

    //public void OnDestroy()
    //{
    //    GameManager.Instance.OnChangePhase -= EscapeDirection;
    //}
    //public void OnApplicationQuit()
    //{
    //    Debug.Log("OnchangePahse");
    //    GameManager.Instance.OnChangePhase -= EscapeDirection;
    //}

    #endregion MONO

    #region METHODES

    #region ABSTRACTS

    public abstract void Init(Transform target);

    public abstract void EscapeDirection();

    #endregion ABSTRACTS

    #endregion METHODES

}


///
/// Problème de vitesse sur le changement de direction
/// La fonction EscapeDirection ne s'ajoute pas dans l'event OnChangePhase 
///