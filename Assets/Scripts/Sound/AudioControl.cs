using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioClip bgMusic;

    private AudioManager audioManager;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();

        audioManager.PlayBGM(bgMusic);
    }
}