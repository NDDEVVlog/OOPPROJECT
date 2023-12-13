using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MovementSound : MonoBehaviour
{
    public DynamicAudio.SoundHolder sound;
    public AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void WalkSound()
    {
        DynamicSound.PlaySound(DynamicAudio.MaterialType.Concrete,sound,this.gameObject);
    }
}
