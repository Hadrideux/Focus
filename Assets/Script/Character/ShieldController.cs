using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Controlle")]
    [SerializeField] private float _speedRotation = 0f;

    [SerializeField] private Vector3 _rotationTarget = Vector3.zero;
    [Range(0f, 1f)]
    [SerializeField] private float _speedAlpha = 0f;


    #endregion ATTRIBUTS

    #region MONO

    // Update is called once per frame
    void Update()
    {
        ShieldRotation();
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

    #endregion METHODES
}
