using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

    AudioClip audioClip;
    AudioSource audioSource;

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Play()
    {
        audioSource.Play();
    }
}
