using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioSource _audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySoundBubble()
    {
        _audioSource.Play();
    }

    public void PlayAmbiantSound()
    {
        _audioSource.Play();
    }
}
