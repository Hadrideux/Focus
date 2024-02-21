using UnityEngine;

public class ShieldController : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Controlle")]
    [SerializeField] private float _speedRotation = 0f;

    [SerializeField] private Vector3 _rotationTarget = Vector3.zero;
    [Range(0f, 1f)]
    [SerializeField] private float _speedAlpha = 0f;

    [Header("Focus Type")]
    [SerializeField] private ETypeThink[] _thinkFocus = null;
    [SerializeField] private ETypeThink _currentFocus = ETypeThink.NONE;

    #endregion ATTRIBUTS

    #region MONO

    private void Start()
    {
        SetFocusRequirement();
    }
    // Update is called once per frame
    void Update()
    {
        ShieldRotation();
    }

    void OnTriggerEnter(Collider other)
    {
        AThinkingBubble thinkingBubble = other.GetComponentInParent<AThinkingBubble>();
        FocusStability(thinkingBubble);
    }

    #endregion MONO

    #region METHODES

    //Controlle de la rotation des bouclier
    private void ShieldRotation()
    {
        _rotationTarget = new Vector3(0, 0, Input.GetAxis("Horizontal") * _speedRotation * Time.deltaTime);
    
        Vector3 eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + _rotationTarget.z);
        Vector3 lerp = Vector3.Lerp(transform.eulerAngles, eulerAngles, _speedAlpha);

        transform.rotation = Quaternion.Euler(lerp);
    }

    private void FocusStability(AThinkingBubble thinkBubble)
    {
        switch (thinkBubble.TypeThink == _currentFocus)
        {
            case true:
                Debug.Log("Good Focus : Bubble : " + thinkBubble.TypeThink + "\nFocus : " + _currentFocus);
                break;
            
            case false:
                Debug.Log("Bad Focus : Bubble : " + thinkBubble.TypeThink + "\nFocus : " + _currentFocus);
                break;
        }
    }

    private void SetFocusRequirement()
    {
        _currentFocus = _thinkFocus[Random.Range(0, _thinkFocus.Length - 1)];
    }
    #endregion METHODES
}
