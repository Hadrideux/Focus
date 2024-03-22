using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBubble : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private AnimationClip _deathAnim = null;

    // Start is called before the first frame update
    void Start()
    {
        //_animator.Play();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
