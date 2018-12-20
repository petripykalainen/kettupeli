using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

    AudioSource soundPlayer;
    [SerializeField] AudioClip hoverSound, clickSound;

    private void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    public void PlayHoverSound()
    {
        soundPlayer.PlayOneShot(hoverSound);
    }

    public void PlayClickSound()
    {
        soundPlayer.PlayOneShot(clickSound);
    }
}
