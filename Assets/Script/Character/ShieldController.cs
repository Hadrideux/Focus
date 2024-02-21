using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 0f;

    [SerializeField] private Vector3 _rotationTarget = Vector3.zero;
    [Range(0f, 1f)]
    [SerializeField] private float _speedAlpha = 0f;

    // Update is called once per frame
    void Update()
    {
        ShieldRotation();
    }

    private void ShieldRotation()
    {
        _rotationTarget = new Vector3(0, 0, Input.GetAxis("Horizontal") * _speedRotation * Time.deltaTime);
    
        Vector3 eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + _rotationTarget.z);
        Vector3 lerp = Vector3.Lerp(transform.eulerAngles, eulerAngles, _speedAlpha);

        transform.rotation = Quaternion.Euler(lerp);
    }
}
