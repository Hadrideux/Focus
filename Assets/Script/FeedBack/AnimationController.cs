using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Bubble Anim")]
    [SerializeField] private Animation _spawnAnim = null;
    [SerializeField] private Animation _deathAnim = null;
    [SerializeField] private Animation _idleAnim = null;

    [Header("Character Anim")]
    [SerializeField] private Animation _characterAnim = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySpawnAnim()
    {
        _spawnAnim.Play();
    }

    public void PlayIdleAnim()
    {
        _idleAnim.Play();
    }

    public void PlayDeathAnim()
    {
        _deathAnim.Play();
    }

    public void PlayCharacterAnim()
    {
        _characterAnim.Play();
    }
}
